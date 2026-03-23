using System.Drawing;
using UnityEngine;
using TMPro;

public class GameManger : MonoBehaviour
{
    private Player player;
    [SerializeField] private float healValue = 20f;
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        HealPlayer();
    }
    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }
    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
    private void HealPlayer()
    {
        if (player != null)
        {
            player.Heal(healValue);
        }
    }
}
