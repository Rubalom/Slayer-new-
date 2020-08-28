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
    private int attackToRight = 1;
    [HideInInspector] public bool attack = false;
    [HideInInspector] public bool attackDelay = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKey(KeyCode.UpArrow) && (jump == false))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetKey(KeyCode.Space) && (attack == false) && (attackDelay == false) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attacking"))
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                attackToRight = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                attackToRight = 1;
            }
            else
            {
                attackToRight = controller.GetFacing() ? 1 : -1;
            }
            
            attack = true;
            attackDelay = true;
            animator.SetBool("IsAttacking", true);
        }

    }

    private void FixedUpdate()
    {
        if (!attack)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        }
        else
        {
            controller.Move(attackToRight * Time.fixedDeltaTime * speed * 1.2f, false);
        }
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void GroundPlayer()
    {
        controller.GroundPlayer();
    }


}
