using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private float timeDestroy = 20f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DestroyCoin();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
    }
    private void DestroyCoin()
    {
        Destroy(gameObject, timeDestroy);
    }
    private void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
