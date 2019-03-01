using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For 3rd person controlls
public class PlayerController : MonoBehaviour
{
    Transform shipTransform;

    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;
    [SerializeField] float fastMovementSpeed = 100f;
    float deltaTime;

    Space worldSpace = Space.World;
    string horizontal = "Horizontal";
    string pitch = "Pitch";
    string roll = "Roll";
    string vertical = "Vertical";


	void Awake ()
    {
        if (shipTransform == null)
        {
            shipTransform = GetComponent<Transform>();
        }

        deltaTime = Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Turn();
        Thrust();
	}

    void Turn()
    {
        float _yaw = turnSpeed * deltaTime * Input.GetAxis(horizontal);
        float _pitch = turnSpeed * deltaTime * Input.GetAxis(pitch);
        float _roll = turnSpeed * deltaTime * Input.GetAxis(roll);

        shipTransform.Rotate(_pitch, _yaw, _roll);
    }

    void Thrust()
    {
        float _vert = Input.GetAxisRaw(vertical);
        bool _fastVert = Input.GetKey(KeyCode.LeftShift);

        // If input is detected & going normal speed
        if (_vert > 0)
        {
            shipTransform.position += shipTransform.forward * movementSpeed * deltaTime;
        }

        // If input is detected and going fast
        if ((_vert > 0) && _fastVert)
        {
            shipTransform.position += shipTransform.forward * fastMovementSpeed * deltaTime;
        }
    }
}
