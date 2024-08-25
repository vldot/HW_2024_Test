using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float timerDuration = 5f;
    private float remainingTime;
    public TextMeshProUGUI timerText;

    void Start()
    {
        remainingTime = timerDuration;
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
            Destroy(gameObject);
        }
    }
}
