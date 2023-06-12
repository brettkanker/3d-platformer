using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewindScript : MonoBehaviour
{
    public static Transform respawnPoint;
    private float heightThreshold = -2f; // 2 units bellow y=0

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.R))
        {
            RespawnPlayer();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            respawnPoint = other.gameObject.transform;
        }
    }

    public void RespawnPlayer()
    {
        // Destroy the clone game object if it exists
        if (respawnPoint != null)
        {
            GameObject clone = GameObject.Find("Player(Clone)");
            if (clone != null)
            {
                Destroy(clone);
                CloneScript.cloneCreated = false;
            }

            // Reset the player's position to the respawn point
            Transform player = GameObject.Find("Player").transform.Find("Body");
            if (player != null)
            {
                player.position = respawnPoint.position;
            }
            
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            CloneScript.cloneCreated = false;
        }
            
    }
}
