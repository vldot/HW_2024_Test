using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float minPulpitDestroyTime = 4f;
    public float maxPulpitDestroyTime = 5f;
    public TextMeshProUGUI timerText;
    private float destroyTime;
    private float remainingTime;
    private bool isScalingDown = false;
    public GameObject pulpitPrefab;
    private ScoreManager scoreManager;

    void Start()
    {
        destroyTime = Random.Range(minPulpitDestroyTime, maxPulpitDestroyTime);
        remainingTime = destroyTime;
        scoreManager = FindObjectOfType<ScoreManager>();
        StartCoroutine(SpawnPulpitBeforeDestroy());
    }

    void Update()
    {
        if (remainingTime > 0 && !isScalingDown)
        {
            remainingTime -= Time.deltaTime;
            timerText.text = remainingTime.ToString("F2");
        }
        else if (!isScalingDown)
        {
            StartCoroutine(ScaleDownAndDestroy());
        }
    }

    IEnumerator ScaleDownAndDestroy()
    {
        isScalingDown = true;
        Vector3 initialScale = transform.localScale;
        float scaleTime = 0.5f;
        for (float t = 0; t < scaleTime; t += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, t / scaleTime);
            yield return null;
        }
        scoreManager.AddScore(1);
        Destroy(gameObject);
    }

    IEnumerator SpawnPulpitBeforeDestroy()
    {
        yield return new WaitForSeconds(destroyTime - 2.5f);
        SpawnNewPulpit();
    }

    void SpawnNewPulpit()
    {
        Vector3 spawnPosition = Vector3.zero;
        float gridWidth = 9f;
        float gridHeight = 9f;

        int side = Random.Range(0, 4);

        switch (side)
        {
            case 0: // Top side
                spawnPosition = new Vector3(transform.position.x, 0, transform.position.z + gridHeight);
                break;
            case 1: // Bottom side
                spawnPosition = new Vector3(transform.position.x, 0, transform.position.z - gridHeight);
                break;
            case 2: // Left side
                spawnPosition = new Vector3(transform.position.x - gridWidth, 0, transform.position.z);
                break;
            case 3: // Right side
                spawnPosition = new Vector3(transform.position.x + gridWidth, 0, transform.position.z);
                break;
        }

        Instantiate(pulpitPrefab, spawnPosition, Quaternion.identity);
    }
}
