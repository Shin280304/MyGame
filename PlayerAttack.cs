using UnityEngine;

public class PlayerAttackl : MonoBehaviour
{
    Animator ani;
    bool trigger;
    public int combo;
    public int comboNumber;
    public bool attacking;
    public float comboTimming;
    public float comboTempo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ani = GetComponent<Animator>();
        combo = 1;
        comboTimming = 0.5f;
        comboTempo = comboTimming;
        comboNumber = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    public void Attack()
    {
        comboTempo -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.J) && comboTempo < 0)
        {
            attacking = true;
            ani.SetTrigger("Attack" + combo);
            comboTempo = comboTimming;
        }
        else if (Input.GetKeyDown(KeyCode.J) && comboTempo > 0 && comboTempo < 0.3)
        {
            attacking = true;
            combo++;
            if (combo > comboNumber)
            {
                combo = 1;
            }
            ani.SetTrigger("Attack" + combo);
            comboTempo = comboTimming;
        }
        else if (comboTempo < 0 && !Input.GetKeyDown(KeyCode.J))
        {
            attacking = false;
        }
        if (comboTempo < 0)
        {
            combo = 1;
        }
    }
}
