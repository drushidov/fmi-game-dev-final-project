using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1.0f;
    public float maxDistance = 20.0f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        transform.position += transform.forward * Time.fixedDeltaTime * speed;

        if (Vector3.Distance(initialPosition, transform.position) >= maxDistance)
        {
            Destroy(this.gameObject);
        }
    }
}
