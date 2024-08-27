using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class MoveScript : MonoBehaviour
{
    public int speed = 800; // Default value
    private bool isRotating = false;
    private string jsonUrl = "https://s3.ap-south-1.amazonaws.com/superstars.assetbundles.testbuild/doofus_game/doofus_diary.json";
    public ScoreManager scoreManager;

    void Start()
    {
        if (scoreManager == null) {
            scoreManager = FindObjectOfType<ScoreManager>();
        }
        StartCoroutine(FetchDataFromJson());
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Pulpit"))
        {
            scoreManager.AddScore(1);
        }
    }

    void Update() {
        if (isRotating) {
            return;
        }

        if (Input.GetKey(KeyCode.D) && !isRotating) {
            StartCoroutine(Roll(Vector3.right));
        } else if (Input.GetKey(KeyCode.A) && !isRotating) {
            StartCoroutine(Roll(Vector3.left));
        } else if (Input.GetKey(KeyCode.W) && !isRotating) {
            StartCoroutine(Roll(Vector3.forward));
        } else if (Input.GetKey(KeyCode.S) && !isRotating) {
            StartCoroutine(Roll(Vector3.back));
        }
    }

    IEnumerator Roll(Vector3 direction) {
        isRotating = true;

        float remainingAngle = 90;
        Vector3 rotationCenter = transform.position + direction / 2 + Vector3.down / 2;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

        while (remainingAngle > 0) {
            float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;
            yield return null;
        }

        isRotating = false;
    }

    IEnumerator FetchDataFromJson()
    {
        UnityWebRequest request = UnityWebRequest.Get(jsonUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = request.downloadHandler.text;
            DoofusData data = JsonUtility.FromJson<DoofusData>(json);

            speed = data.player_data.speed * 150;
            Debug.Log("Speed updated: " + speed);
        }
        else
        {
            Debug.LogError("Failed to load JSON data: " + request.error);
        }
    }
}

[System.Serializable]
public class DoofusData
{
    public PlayerData player_data;
}

[System.Serializable]
public class PlayerData
{
    public int speed;
}
