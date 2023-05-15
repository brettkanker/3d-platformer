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
            else
            {
                //gameObject.transform.position.x = target.position.x + offset.x;
                Vector3 newPosition = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);
                transform.position = newPosition;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isColliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }
}
