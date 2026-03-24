using UnityEngine;

public class HealItem : MonoBehaviour
{
    [SerializeField] private float healAmount = 20f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();

            if (player != null)
            {
                player.Heal(healAmount);
                Destroy(gameObject); // biến mất sau khi nhặt
            }
        }
    }
}
