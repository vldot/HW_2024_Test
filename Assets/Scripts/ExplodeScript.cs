using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeScript : MonoBehaviour
{
    public int cubesPerAxis = 8;
    public float delay = 1f;
    public float force = 300f;
    public float radius = 2f;

    void Start() {
        Invoke("Main", delay);
    }

    void Main() {
        for (int x = 0; x < cubesPerAxis; x++) {
            for (int y = 0; y < cubesPerAxis; y++) {
                for (int z = 0; z < cubesPerAxis; z++) {
                    CreatePiece(new Vector3(x, y, z));
                }
            }
        }
        
        Destroy(gameObject);
    }

    void CreatePiece(Vector3 coordinates) {
        GameObject piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // piece.transform.position = transform.position + coordinates;
        // piece.transform.localScale = new Vector3(1f / cubesPerAxis, 1f / cubesPerAxis, 1f / cubesPerAxis);
        // piece.AddComponent<Rigidbody>();
        // piece.GetComponent<Rigidbody>().mass = 0.2f;
        // piece.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius);
        // Destroy(piece, 5f);
         
         Renderer rend = piece.GetComponent<Renderer>();
         rend.material = GetComponent<Renderer>().material;

         piece.transform.localScale = transform.localScale / cubesPerAxis;

         Vector3 firstPiece = transform.position - transform.localScale / 2 + piece.transform.localScale / 2;
         piece.transform.position = firstPiece + Vector3.Scale(coordinates, piece.transform.localScale);

         Rigidbody rb = piece.AddComponent<Rigidbody>();
         rb.AddExplosionForce(force, transform.position, radius);
    }
}
