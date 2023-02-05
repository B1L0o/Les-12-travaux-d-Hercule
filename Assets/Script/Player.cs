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
    
    public float moveSpeed;
    public float jumpForce;

    public bool isJumping;
    public bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public float attackDelay;
    public Transform weaponTransform;
    public float weaponRange;
    public int weaponDamage;
    public LayerMask ennemyPlayer;
    
    

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    
    public Vector3 velocity = Vector3.zero;
    public float horizontalMovement;

    public int health;
    public int maxHealth;
    public HealthBar healthBar;

    public void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        MovePlayer(horizontalMovement);

    }
    
    void Start()
    { 
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update ()
    {
        // Jump Part 
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        
        // The Highest you are the Highest the gravity is 










        // Code For Sprite Display
        Flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);

        
        
        
        //Attack and Damage
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(TakeDMG(10));
        }
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Attack());
        }
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f,jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    IEnumerator Attack()
    {
        animator.Play("PlayerSwordSlash_");
        yield return new WaitForSeconds(attackDelay);
    }
    
    IEnumerator TakeDMG(int _damage)
    {
        health -= _damage;
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        yield return new WaitForSeconds(attackDelay);
    }
}
