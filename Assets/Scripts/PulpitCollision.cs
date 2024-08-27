using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulpitCollision : MonoBehaviour
{
    private ScoreManager scoreManager;
    private bool collisionEnabled = false;
    public float collisionDelay = 1.0f;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        StartCoroutine(EnableCollisionAfterDelay());
    }

    IEnumerator EnableCollisionAfterDelay()
    {
        yield return new WaitForSeconds(collisionDelay);
        collisionEnabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collisionEnabled && collision.gameObject.CompareTag("Player"))
        {
            HandleCollision();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collisionEnabled && other.CompareTag("Player"))
        {
            HandleCollision();
        }
    }

    private void HandleCollision()
    {
        scoreManager.AddScore(1);
        Destroy(gameObject);
    }
}
