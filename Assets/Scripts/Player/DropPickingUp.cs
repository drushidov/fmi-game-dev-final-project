using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPickingUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            Debug.Log("Picked up a pickup");
            Destroy(other.gameObject);
        }
    }
}
