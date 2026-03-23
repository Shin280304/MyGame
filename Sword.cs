using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private Transform firePos; // Vị trí bắn
    [SerializeField] private GameObject bulletPrefabs; // Prefab viên đạn
    [SerializeField] private float shotDelay = 0.1f; // Thời gian delay giữa các phát bắn
    private float nextShot;
    [SerializeField] private int maxAmmo = 100; // Số đạn tối đa
    private int currentAmmo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.J) && currentAmmo > 0 && Time.time > nextShot)
        {
            nextShot = Time.time + shotDelay;
            // Lấy hướng hiện tại của player
            float direction = transform.localScale.x; // 1 nếu nhân vật quay sang phải, -1 nếu quay sang trái
            Vector2 bulletDirection = new Vector2(direction, 0); // Tạo vector hướng theo X

            // Tạo viên đạn và gán hướng cho nó
            GameObject bullet = Instantiate(bulletPrefabs, firePos.position, firePos.rotation);
            bullet.GetComponent<PlayerBullet>().SetDirection(bulletDirection); // Đặt hướng viên đạn
            PlayerBullet pb = bullet.GetComponent<PlayerBullet>();
            pb.SetDirection(bulletDirection);

            // Lật sprite theo hướng
            Vector3 bulletScale = bullet.transform.localScale;
            bulletScale.x = Mathf.Abs(bulletScale.x) * direction; // nhân với 1 hoặc -1
            bullet.transform.localScale = bulletScale;
        }
    }
}
