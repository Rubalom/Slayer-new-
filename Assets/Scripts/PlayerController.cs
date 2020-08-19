using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 40f;

    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController2D controller;
    private Rigidbody2D rb;

    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKey(KeyCode.UpArrow))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("IsAttacking", true);
        }

    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
