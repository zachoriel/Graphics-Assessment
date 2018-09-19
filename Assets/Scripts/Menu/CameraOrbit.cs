using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public GameObject bob;
    public float speed;

    void Update()
    {
        gameObject.transform.RotateAround(bob.transform.position, -Vector3.up, speed * Time.deltaTime);
    }
}
