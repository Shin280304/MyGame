using UnityEngine;
using UnityEngine.Rendering;

public class HealItemRise : MonoBehaviour
{
    [SerializeField] private float riseSpeed = 0.5f;
    [SerializeField] private float riseHeight = 1f;
    private Vector3 targetPos;
    private bool rising = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPos = transform.position + Vector3.up * riseHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if (rising)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, riseSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                rising = false;
            }
        }
    }
}
