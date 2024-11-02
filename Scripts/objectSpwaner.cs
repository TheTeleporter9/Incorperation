using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpwaner : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("converour"))
        {
            Debug.Log("Collision detected!");
        } else {
            Destroy(this);
        }
    }
}
