using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    [SerializeField] private GameObject healItem;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isOpened = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenChest()
    {
        if(isOpened) return;
        isOpened = true;
        anim.SetTrigger("ChestOpen");
        Debug.Log("Chest Open");
        GameObject heal = Instantiate(healItem, transform.position, Quaternion.identity);
        Rigidbody2D rb = heal.GetComponent<Rigidbody2D>();
    }
}
