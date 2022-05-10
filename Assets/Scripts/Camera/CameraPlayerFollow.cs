using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 positionDifference;

    void Start()
    {
        positionDifference = player.transform.position - transform.position;
    }

    void Update()
    {
        transform.position = player.transform.position - positionDifference;
    }
}
