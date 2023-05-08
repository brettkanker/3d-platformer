using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindScript : MonoBehaviour
{
    public Transform respawnPoint;
    private float heightThreshold = -2f; // 2 units bellow y=0

    void LateUpdate()
    {
        if (transform.position.y < heightThreshold && Input.GetKey(KeyCode.R))
        {
            transform.position = respawnPoint.position;

            // Destroy the clone game object if it exists
            GameObject clone = GameObject.Find("Player(Clone)");
            if (clone != null)
            {
                Destroy(clone);
                CloneScript.cloneCreated = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            respawnPoint = other.transform;
        }
    }
}
