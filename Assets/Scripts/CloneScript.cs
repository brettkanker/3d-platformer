using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public Camera playerCamera;
    public Camera cloneCamera;
    public Transform bodyTransform;

    private GameObject clone;
    private bool cloneCreated = false;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!cloneCreated)
            {
                Vector3 spawnPosition = bodyTransform.position + Vector3.right * 5f;
                clone = Instantiate(playerPrefab, spawnPosition, transform.rotation);

                // Find the clone camera component in the clone object's hierarchy
                cloneCamera = clone.GetComponentInChildren<Camera>();
                cloneCamera.enabled = false;

                // Disable the audio listener of the clone camera
                AudioListener cloneAudioListener = cloneCamera.GetComponent<AudioListener>();
                cloneAudioListener.enabled = false;

                cloneCreated = true;
            }
            else
            {
                // destroy the clone and set cloneCreated to false
                Destroy(clone);
                cloneCreated = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            // Toggle the player camera and clone camera visibility
            playerCamera.enabled = !playerCamera.enabled;
            cloneCamera.enabled = !cloneCamera.enabled;
        }
    }
}
