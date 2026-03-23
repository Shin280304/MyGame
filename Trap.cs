using UnityEngine;

public class Trap : MonoBehaviour
{
    private Player player;
    void Start()
    {
        player=FindAnyObjectByType<Player>();
    }
    public float bounceForce = 10f;
    public int damage = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandlePlayerBounce(collision.gameObject);
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
    private void HandlePlayerBounce(GameObject player)
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb)
        {
            //player bị bật lùi
            rb.linearVelocity=new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up*bounceForce, ForceMode2D.Impulse);
        }
    }
}
