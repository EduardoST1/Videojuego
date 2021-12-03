using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed=2;

    public float jumpSpeed=3;

    Rigidbody2D rb2D;

    public bool betterjump = false;

    public float fallMultiplayer = 0.5f;

    public float lowjumpMultiplayer = 1f;

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Correr", true);
            

        }
        else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Correr", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Correr", false);
        }
        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }

        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Salto", true);
            animator.SetBool("Correr", false);
        }
        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Salto", false);
            
        }

        if (betterjump) 
        {
            if (rb2D.velocity.y<0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplayer) * Time.deltaTime;
            }
            if (rb2D.velocity.y>0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowjumpMultiplayer) * Time.deltaTime;
            }
        }
    }
}
