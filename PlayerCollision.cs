using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManger gameManager;
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManger>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            gameManager.AddScore(1);
        }
        else if (collision.CompareTag("Trap"))
        {
            Debug.Log("Ui Dau Qua");
        }
    }

}
