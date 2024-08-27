using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetection : MonoBehaviour
{
    public float fallThreshold = -10f;
    private bool gameOverTriggered = false;

    void Update()
    {
        if (!gameOverTriggered && transform.position.y < fallThreshold)
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        gameOverTriggered = true;
        SceneManager.LoadScene(2);
    }
}
