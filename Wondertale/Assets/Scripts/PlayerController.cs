using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    public float runSpeed;
    public float speed;
    public float rotationSpeed;
    public float jumpForce = 7;
    public float gravity = -20;
    private bool isCrawling = false;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;
    public Transform model;
    public static bool playerControlsEnabled = true;
    public GameObject navButton;


    private void Update()
    {
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
                    animator.SetBool("isCrouching", true);
                    speed = 1;
                    runSpeed = 1;
                    isCrawling = true;

                }
                else
                {
                    animator.SetBool("isCrouching", false);
                    speed = 1.7f;
                    isCrawling = false;
                }

                if (Input.GetButtonDown("Jump"))
                {
                    direction.y = jumpForce;
                }

                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.JoystickButton2))
                {

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


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dialogue")

        {
            navButton.SetActive(true);
        }
    }
}
