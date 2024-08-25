using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public int speed = 300;
    private bool isRotating = false;

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
}
