using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 50.0f; 

    [Header("Smoothing")]
    public bool smooth = true;
    public float acceleration = 0.1f;
    private float actSpeed = 0.0f;
    private Vector3 lastDir = new Vector3();

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            dir.z += 1.0f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            dir.z -= 1.0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            dir.x -= 1.0f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            dir.x += 1.0f;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            dir.y += 1.0f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            dir.y -= 1.0f;
        }

        dir.Normalize();

        if (dir != Vector3.zero)
        {
            // Movement
            if (actSpeed < 1)
            {
                actSpeed += acceleration * Time.deltaTime * 40;
            }
            else
            {
                actSpeed = 1.0f;
            }

            lastDir = dir;
        }
        else
        {
            // Stop movement over time
            if (actSpeed > 0)
                actSpeed -= acceleration * Time.deltaTime * 20;
            else
                actSpeed = 0.0f;
        }

        if (smooth == true)
        {
            transform.Translate(lastDir * actSpeed * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(dir * speed * Time.deltaTime);
        }
    }

    void OnGUI()
    {
        GUILayout.Box("actSpeed: " + actSpeed.ToString());
    }
}
