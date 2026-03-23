using UnityEngine;
using UnityEngine.UI;
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float enemyMoveSpeed = 1f;
    [SerializeField] protected float maxHP = 50f;
    protected float currentHp;
    [SerializeField] private Image HpBar;
    [SerializeField] protected float enterDamage = 10f;
    [SerializeField] protected float stayDamage = 1f;
    [SerializeField] private GameObject coinObject;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D rb;
    private bool isGrounded;
    protected Player player;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<Player>();
        currentHp = maxHP;
        UpdateHpBar();
    }
    protected virtual void Update()
    {
        GroundCheck();
        MoveToPlayer();
    }
    protected void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    protected void MoveToPlayer()
    {   
        if(!isGrounded) return;
        if (player == null) return;

        Vector2 target = new Vector2(player.transform.position.x, transform.position.y);

        rb.transform.position = Vector2.MoveTowards(
            rb.transform.position,
            target,
            enemyMoveSpeed * Time.deltaTime
        );

        FlipEnemy();
    }

    protected void FlipEnemy()
    {
        transform.localScale = new Vector3(player.transform.position.x < transform.position.x ? -1 : 1, 1, 1);
    }
    public virtual void TakeDamage(float damage)
    {
        currentHp-=damage;
        currentHp = Mathf.Max(currentHp, 0);
        UpdateHpBar();
        if (currentHp <= 0)
        {
            GameObject coin = Instantiate(coinObject, transform.position, Quaternion.identity);
            Rigidbody2D rb = coin.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
            // Tạo lực ngẫu nhiên cho coin
                Vector2 randomForce = new Vector2( 
                    Random.Range(-5f, 5f), // Lực Ngang Trái/Phải
                    Random.Range(6f, 10f)); // Lực Nảy Lên
                rb.AddForce(randomForce, ForceMode2D.Impulse);
            }
            Destroy(coin, 5f);
            Die();
        }
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
    protected void UpdateHpBar(){
        if (HpBar != null)
        {
            HpBar.fillAmount = currentHp / maxHP;
        }
    }
}