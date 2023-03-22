using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed, jumpSpeed, groundCheckRadius;
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public AudioSource jumpSound;
    [SerializeField] private Rigidbody2D rb;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 30f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;









    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    private void Update()
    {
        if (isDashing)
        {
            return;
        }
        //Player ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        //Player movement
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0f);
        }
        else
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }

        //Player jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, 0f);
            jumpSound.Play();
        }

        if (Input.GetKeyDown(KeyCode.B) && canDash)
        {
            StartCoroutine(Dash());
        }






    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }








}