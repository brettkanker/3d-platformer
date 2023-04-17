using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneScript : MonoBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {
        Vector3 spawnPosition = transform.position + Vector3.right * 5f;
        GameObject clone = Instantiate(playerPrefab, spawnPosition, transform.rotation);
        clone.GetComponentInChildren<Camera>().enabled = false;
    }

    void Update()
    {
        
    }
}
