using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public Camera playerCamera;
    public Camera cloneCamera;
    public Transform bodyTransform;
    [SerializeField]
    private float cloneDistance = 5f;

    private GameObject clone;
    public static bool cloneCreated = false;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!cloneCreated)
            {
                Vector3 spawnPosition = bodyTransform.position + Vector3.right * cloneDistance;
                clone = Instantiate(playerPrefab, spawnPosition, transform.rotation);

                // Find the clone camera component in the clone object's hierarchy
                cloneCamera = clone.GetComponentInChildren<Camera>();
                cloneCamera.enabled = false;

                // Disable the audio listener of the clone camera
                AudioListener cloneAudioListener = cloneCamera.GetComponent<AudioListener>();
                cloneAudioListener.enabled = false;

                // Set the x position of the cloneCamera to 0.5
                cloneCamera.transform.localPosition = new Vector3(0.5f, cloneCamera.transform.localPosition.y, cloneCamera.transform.localPosition.z);

                cloneCreated = true;
            }
            else
            {
                // If the clone camera is not enabled, switch to the player camera
                if (cloneCamera.enabled)
                {
                    playerCamera.enabled = true;
                    cloneCamera.enabled = false;
                }

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
