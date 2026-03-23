using UnityEngine;

public class RedSlime : Enemy
{
    [SerializeField] private GameObject ExplosionPrefab;
    private void CreateExplosion()
    {
        if (ExplosionPrefab != null)
        {
            Instantiate(ExplosionPrefab, transform.position,Quaternion.identity);
        }
    }
    public override void Die()
    {
        CreateExplosion();
        base.Die();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CreateExplosion();
            Destroy(gameObject);
        }
    }
}
