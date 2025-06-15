/*
 * Author: GrobenTham
 * Date: 2025-06-15
 * Description: Manages the player's score and updates the TextMeshPro UI.
 */

using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText; // ✅ TextMeshPro type

    private int score = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreUI();
        Debug.Log("Score updated: " + score);
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        else
            Debug.LogWarning("ScoreText reference is missing!");
    }
}
