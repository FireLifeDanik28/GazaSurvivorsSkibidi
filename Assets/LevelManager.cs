using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    int playerHealth;
    int points;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Kills: " + points.ToString();
        healthText.text = "Hp: " + playerHealth.ToString();
    }
    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
    }
    public void ReducePlayerHealth(int amount)
    {
        playerHealth -= amount;
        if (playerHealth <= 0)
        {
            // zatrzymaj gre
            Time.timeScale = 0;
            Debug.Log("Game Over");
            GameOverPanel.SetActive(true);
        }
    }
    public void RestartGame()
    {
        GameOverPanel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}