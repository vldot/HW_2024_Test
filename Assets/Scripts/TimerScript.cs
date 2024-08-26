using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float minPulpitDestroyTime = 4f;
    public float maxPulpitDestroyTime = 5f;
    public float pulpitSpawnTime = 2.5f;
    public TextMeshProUGUI timerText;
    public GameObject pulpitPrefab;

    private float destroyTime;
    private float remainingTime;

    void Start()
    {
        destroyTime = Random.Range(minPulpitDestroyTime, maxPulpitDestroyTime);
        remainingTime = destroyTime;
        StartCoroutine(SpawnPulpitBeforeDestroy());
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            timerText.text = Mathf.Ceil(remainingTime).ToString() + "s";
        }
        else
        {
            Destroy(pulpitPrefab);
        }
    }

    IEnumerator SpawnPulpitBeforeDestroy()
    {
        yield return new WaitForSeconds(destroyTime - pulpitSpawnTime);
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
