using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 offset;
    private bool isColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        offset = gameObject.transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isColliding)
        {
            gameObject.transform.position = target.position + offset;
        }
        else
        {
            if(offset.magnitude <= (gameObject.transform.position - target.position).magnitude)
            {
                gameObject.transform.position = target.position + offset;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isColliding = true;
        Debug.Log(isColliding);
    }

    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
        Debug.Log(isColliding);
    }
}
