using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For 3rd person controlls
public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;
    [SerializeField] float fastMovementSpeed = 100f;

    Transform shipTransform;

	void Awake ()
    {
        shipTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Turn();
        Thrust();
	}

    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");

        shipTransform.Rotate(pitch, yaw, roll);
    }

    void Thrust()
    {
        // If input is detected & going normal speed
        if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1))
        {
            shipTransform.position += shipTransform.forward * movementSpeed * Time.deltaTime;
        }

        // If input is detected and going fast
        if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1) && Input.GetKey(KeyCode.LeftShift))
        {
            shipTransform.position += shipTransform.forward * fastMovementSpeed * Time.deltaTime;
        }
    }
}
