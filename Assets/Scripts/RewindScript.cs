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
            Debug.Log("Respawn point set to: " + respawnPoint.position);
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
                Debug.Log("Destroyed clone");
            }

            // Reset the player's position to the respawn point
            Transform player = GameObject.Find("Player").transform.Find("Body");
            Debug.Log(player.position);
            if (player != null)
            {
                player.position = respawnPoint.position;
                Debug.Log("teleported");
                Debug.Log(player.position);
            }
            
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
            
    }
}
