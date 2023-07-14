using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;            // Movement speed
    public float jumpForce = 5f;            // Jump force
    public float scale;
    public Transform groundCheck;           // Ground check object
    public float groundCheckRadius = 0.2f;  // Radius of the ground check sphere
    public LayerMask groundLayer;           // Layer mask for the ground
    public Animator characterAnimation;
    public bool isMoving = false;

    float moveHorizontal;
    float moveVertical;

    private Rigidbody2D rb;
    private bool isJumping = false;
    private bool isGrounded = false;

    public bool isLadder;
    public bool isClimbing;

    public int health = 3;
    public Image[] hearts;
    public Sprite fullHearth;
    public Sprite emptyHearth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Move the player horizontally
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);

        if (moveHorizontal != 0)
        {
            isMoving = true;
            characterAnimation.SetBool("walking", true);
        }
        else
        {
            isMoving = false;
            characterAnimation.SetBool("walking", false);
        }

        if (moveHorizontal > 0 || moveHorizontal < 0)
        {
            transform.localScale = new Vector2(scale * moveHorizontal, scale);
        }

        // Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump when Space key is pressed and the player is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            Debug.Log("Lompat");
        }

        // Apply jump force if the player is jumping
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            Debug.Log("terbanggg");
            isJumping = false;
        }

        // CLimbing with ladder
        if (isLadder && Mathf.Abs(moveVertical) > 0f)
        {
            isClimbing = true;
        }

        //hearth Manager
        healthManager();
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, moveVertical * moveSpeed);
        }
        else
        {
            rb.gravityScale = 30f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }

        if (collision.tag == "enemy")
        {
            Debug.Log("Waduh");
            health--;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }

    private void healthManager()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHearth;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHearth;
        }
    }
}
