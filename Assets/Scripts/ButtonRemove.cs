using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRemove : MonoBehaviour
{
    [SerializeField] 
    private GameObject objectToRemove;

    private void OnMouseDown()
    {
        if (objectToRemove != null)
        {
            Destroy(objectToRemove);
        }
    }
}
