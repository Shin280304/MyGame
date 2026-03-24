using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float damage = 25f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        Enemy enemy = collision.GetComponent<Enemy>();
        if(collision.CompareTag("Player") && player != null)
        {
            player.TakeDamage(damage);
        }
        else if(collision.CompareTag("Enemy") && enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
    public void DestroyExplosion()
    {
        Destroy(gameObject);
    }
}
