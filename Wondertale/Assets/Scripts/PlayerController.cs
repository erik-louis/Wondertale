using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    public float speed = 8;
    public float jumpForce = 10;
    public float gravity = -20;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator animator;

    private void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;

        animator.SetFloat("speed", Mathf.Abs(hInput));
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        
        if (isGrounded)
        {
            
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpForce;
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }

        controller.Move(direction * Time.deltaTime);
    }

}
