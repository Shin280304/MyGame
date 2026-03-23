using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 50f; // Tốc độ di chuyển của viên đạn
    [SerializeField] private float timeDestroy = 2f; // Thời gian để viên đạn tự hủy
    [SerializeField] private float damage = 10f;
    private Vector2 moveDirection; // Hướng di chuyển của viên đạn

    void Start()
    {
        Destroy(gameObject, timeDestroy);
    }

    // Gọi hàm này từ Sword để thiết lập hướng viên đạn
    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction.normalized; // Normal hóa hướng để tránh tốc độ không đều
    }

    // Update is called once per frame
    void Update()
    {
        moveBullet();
    }

    // Di chuyển viên đạn
    void moveBullet()
    {
        
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if(enemy!=null)
            {
                enemy.TakeDamage(damage);    
            }
            Destroy(gameObject);
        }
        if (collision.CompareTag("Chest"))
        {
            ChestOpen chest = collision.GetComponent<ChestOpen>();
            if (chest != null)
            {
                chest.OpenChest();
            }
        }
    }

}
