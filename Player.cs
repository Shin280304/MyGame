using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float maxHP = 100f;
    [SerializeField] private float hurtTime = 0.2f;
    private float hurtTimer= 0f;
    private bool isHurt = false;
    [SerializeField] private SpriteRenderer sprite;
    private float currentHp;
    [SerializeField] private Image HpBar;
    private Animator animator;
    private Rigidbody2D rb;
    private bool isGrounded;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
        currentHp = maxHP;
        UpdateHpBar();  
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        UpdateAnimations();
        if (isHurt)
        {
            hurtTimer -= Time.deltaTime;

            if (hurtTimer <= 0f)
            {
                isHurt = false;
            }
        }
    }

    // ---------------- MOVEMENT ----------------
    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (moveInput > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);
        
    }

    // ---------------- JUMP ----------------
    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void UpdateAnimations()
    {
        animator.SetBool("isRunning", Mathf.Abs(rb.linearVelocity.x) > 0.1f);
        animator.SetBool("isJumping", !isGrounded);
    }
    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        currentHp = Mathf.Max(currentHp, 0);
        UpdateHpBar();
        isHurt = true;
        hurtTimer = hurtTime;
        animator.SetTrigger("Hurt");
        if (currentHp <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    private void UpdateHpBar()
    {
        if (HpBar != null)
        {
            HpBar.fillAmount = currentHp / maxHP;
        }
    }
    public void Heal(float healValue)
    {
        if (currentHp < maxHP)
        {
            currentHp += healValue;
            currentHp=Math.Min(currentHp, maxHP);
            UpdateHpBar();
        }
    }
}
