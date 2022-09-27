using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    public float runSpeed;
    public float speed;
    public float rotationSpeed;
    public float jumpForce;
    public float gravity;
    private bool isCrawling = false;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;
    public Transform model;
    public static bool playerControlsEnabled = true;
    public GameObject navButton;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject bottleDialogue;

    public static float inputTimer;


    private void Start()
    {
        inputTimer = 0;
    }

    private void Update()
    {
        inputTimer += Time.deltaTime;

        //Player Movement when no Dialogue showing
        if (playerControlsEnabled)
        {
            float hInput = Input.GetAxis("Horizontal");
            float vInput = Input.GetAxis("Vertical");
            direction.x = hInput * speed * runSpeed;
            direction.z = vInput * speed * runSpeed;

            Vector3 movementDirection = new Vector3(hInput, 0, vInput);
            movementDirection.Normalize();

            transform.Translate(movementDirection * speed * runSpeed * Time.deltaTime, Space.World);

            bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);

            animator.SetBool("isGrounded", isGrounded);

            if (isGrounded)
            {
                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.JoystickButton4))
                {
                    inputTimer = 0;
                    animator.SetBool("isCrouching", true);
                    speed = 0.7f;
                    runSpeed = 1;
                    isCrawling = true;
                    controller.center = new Vector3(0, 0.35f, 0);
                    controller.height = 0.67f;

                }
                else
                {
                    animator.SetBool("isCrouching", false);
                    speed = 1;
                    isCrawling = false;
                    controller.center = new Vector3(0, 0.72f, 0);
                    controller.height = 1.43f;
                }

                if (Input.GetButtonDown("Jump"))
                {
                    inputTimer = 0;
                    direction.y = jumpForce;
                    
                }

                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.JoystickButton2))
                {
                    inputTimer = 0;
                    runSpeed = 2;
                    animator.SetTrigger("Run");

                    if (isCrawling == true)
                    {
                        runSpeed = 1;
                    }
                    else
                    {
                        runSpeed = 2;
                    }

                }
                else
                {

                    runSpeed = 1;
                    animator.SetTrigger("Walk");
                }


            }
            else
            {
                direction.y += gravity * Time.deltaTime;
            }

            if (movementDirection != Vector3.zero)
            {
                inputTimer = 0;
                animator.SetBool("isMoving", true);
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
                
                
            }
            else
            {
                animator.SetBool("isMoving", false);
                
            }

            controller.Move(direction * Time.deltaTime);
        }

        //play Idle Animation when Dialogue is on (playerControlsEnabled = false)
        else
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isGrounded", true);
            
        }

        if (Input.GetButtonDown("Pause") || Input.GetKeyDown(KeyCode.Escape))
        {
            inputTimer = 0;
            pauseMenu.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            inputTimer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            inputTimer = 0;
        }

        // Go back to Main Menu after 2 Minutes of inactive input
        if (inputTimer >= 120f)
        {
            inputTimer = 0;
            SceneManager.LoadScene("Main Menu");
            FindObjectOfType<AudioManager>().StopPlaying("Corridor_Atmosphere");
            FindObjectOfType<AudioManager>().StopPlaying("Inside_the_Tent");
            FindObjectOfType<AudioManager>().StopPlaying("StompRoom");
            FindObjectOfType<AudioManager>().Play("mainmenuv2");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // triggers dialogue
        if (other.gameObject.tag == "Dialogue")

        {
            navButton.SetActive(true);
            
        }

        // triggers death animation in stomping minigame
        if (other.gameObject.tag == "Foot")

        {
            playerControlsEnabled = false;
            animator.SetBool("isFlat", true);
            transform.position = new Vector3(transform.position.x, 0.54f, transform.position.z);
            StartCoroutine(ReloadScene());

        }

        // Respawn after fall into abyss
        if (other.gameObject.tag == "Abyss")

        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        // Activate Bottle Dialogue Object after finding Bottle
        if (other.gameObject.tag == "Bottle")

        {
            bottleDialogue.SetActive(true);
            Destroy(other.gameObject);
        }


    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(3f);
        playerControlsEnabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   

    private void LeftFootstepSound()
    {
        FindObjectOfType<AudioManager>().Play("WalkLeft");
    }

    private void RightFootstepSound()
    {
        FindObjectOfType<AudioManager>().Play("WalkRight");
    }

    private void JumpSound()
    {
        FindObjectOfType<AudioManager>().Play("Jump");
    }

    private void CrawlSound()
    {
        FindObjectOfType<AudioManager>().Play("Crawl");
    }


}
