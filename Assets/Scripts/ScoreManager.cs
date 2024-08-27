using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start() {
        UpdateScore();
    }

    public void AddScore(int amount) {
        score += amount;
        Debug.Log("Score updated: " + score);
        UpdateScore();
    }

    private void UpdateScore() {
        scoreText.text = score.ToString();
    }
}
