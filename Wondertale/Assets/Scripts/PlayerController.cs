using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    private float runSpeed = 1;
    public float speed = 8;
    public float jumpForce = 10;
    public float gravity = -20;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;
    public Transform model;
    
    


    private void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed * runSpeed;

        float vInput = Input.GetAxis("Vertical");
        direction.z = vInput * speed * runSpeed;

        animator.SetFloat("speed", Mathf.Abs(hInput));
        animator.SetFloat("speedv", Mathf.Abs(vInput));
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);


        animator.SetBool("isGrounded", isGrounded);
        
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                animator.SetTrigger("Crouch");
            }

            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpForce;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
               
                runSpeed = 2;
                animator.SetTrigger("Run");
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

        if (hInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
            model.rotation = newRotation;
        }

        if (vInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(0, 0, vInput));
            model.rotation = newRotation;
        }

        controller.Move(direction * Time.deltaTime);
    }


}
