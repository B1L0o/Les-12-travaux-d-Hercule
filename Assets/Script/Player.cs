using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    // Jump Variables //
    public bool isJumping;
    public int maxJumps;
    private float jumpForce = 100;
    private float maxButtonHoldTime = .4f;
    private float holdForce = 100;
    private float maxJumpSpeed = 6;
    private float maxFallSpeed = -20;
    private float fallSpeed = 3;
    private float gravityMultipler = 4;
    private bool jumpPressed;
    private bool jumpHeld;
    private float buttonHoldTime;
    private float originalGravity;
    private int numberOfJumpsLeft;
    // Collision Handlers //
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;
    public bool isGrounded;
    // Jump Variables //
    
    
   
    
    
    // Animation Variables //
    private float attackDelay = 1;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    // Animation Variables //
    
    
    
    // Movement Variables //
    public float moveSpeed;
    public Vector3 velocity = Vector3.zero;
    public float horizontalMovement;
    // Movement Variables //

    
    
    // Health Variables //
    public int health;
    public int maxHealth;
    public HealthBar healthBar;
    // Health Variables //

    
    
    public void FixedUpdate()
    {
        MovePlayer(Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime);
        IsJumping();
    }
    
    
    void Start()
    { 
        health = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
        buttonHoldTime = maxButtonHoldTime;
        originalGravity = rb.gravityScale;
        numberOfJumpsLeft = maxJumps;
    }
    

    void Update ()
    {
        // Jump Part //
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }
        else
            jumpPressed = false;
        if (Input.GetKey(KeyCode.Space))
        {
            jumpHeld = true;
        }
        else
            jumpHeld = false;
        CheckForJump();
        GroundCheck();
        // Jump Part //
        

        

        // Sprite Display //
        Flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);

        
        
        
        // Attack and Damage //
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(TakeDMG(10));
        }
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Melee());
        }
        // Attack and Damage //
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);
        
    }

    void Flip(float _velocity) // The side Hercules is facing
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    void TakeDamage(int _damage)
    {
        health -= _damage;
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos() // Displays Circle for hitbox collisions with the grou,d //
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    IEnumerator Melee() // Melee Animation
    {
        animator.Play("PlayerSwordSlash_");
        yield return new WaitForSeconds(attackDelay);
    }
    
    IEnumerator TakeDMG(int _damage) //Simple method used to inflict damage to Hercules
    {
        health -= _damage;
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        yield return new WaitForSeconds(attackDelay);
    }
    

    private void CheckForJump() // Determines if Hercules has remaining jumps 
    {
        if (jumpPressed)
        {
            if (!isGrounded && numberOfJumpsLeft == maxJumps)
            {
                isJumping = false;
                return;
            }
            numberOfJumpsLeft--;
            if (numberOfJumpsLeft >= 0)
            {
                rb.gravityScale = originalGravity;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                buttonHoldTime = maxButtonHoldTime;
               isJumping = true;
            }
        }
    }

    private void IsJumping() //Applies forces upward to make Hercules go boom boom in the air
    {
        if(isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce);
            AdditionalAir();
        }
        if (rb.velocity.y > maxJumpSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxJumpSpeed);
        }
        Falling();
    }

    private void AdditionalAir() // Handles Additional Jumps
    {
        if (jumpHeld)
        {
            buttonHoldTime -= Time.deltaTime;
            if (buttonHoldTime <= 0)
            {
                buttonHoldTime = 0;
                isJumping = false;
            }
            else
                rb.AddForce(Vector2.up * holdForce);
        }
        else
        {
            isJumping = false;
        }
    }

    private void Falling() // Makes Hercules go into the ground, Handles gravity in a way
    {
        if(!isJumping && rb.velocity.y < fallSpeed)
        {
            rb.gravityScale = gravityMultipler;
        }
        if(rb.velocity.y < maxFallSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxFallSpeed);
        }
    }
    
    private void GroundCheck() // Determines whether or not Hercules is grounded ,by using the hitbox under his feets
    {
        if (Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers) && !isJumping)
        {
            isGrounded = true;
            numberOfJumpsLeft = maxJumps;
            rb.gravityScale = originalGravity;
        }
        else
        {
            isGrounded = false;
        }
    }
    
}
