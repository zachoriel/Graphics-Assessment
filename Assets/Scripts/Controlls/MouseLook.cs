using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float speedH;
    public float speedV;

    public float yaw;

    public float pitch;
    public float minPitch;
    public float maxPitch;

    public bool lockCursor = true;
    private bool m_cursorIsLocked = true;

    float ClampAngle(float angle, float from, float to)
    {
        if (angle > 180)
        {
            angle = 360 - angle;
        }

        angle = Mathf.Clamp(angle, from, to);

        if (angle < 0)
        {
            angle = 360 + angle;
        }

        return angle;
    }

    void Start()
    {
        speedH = 5f;
        speedV = 5f;

        minPitch = -90f;
        maxPitch = 90f;
    }

    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * speedH;
        pitch -= Input.GetAxis("Mouse Y") * speedV;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        transform.eulerAngles = new Vector3(pitch, yaw, 0);
        UpdateCursorLock();
    }

    public void SetCursorLock(bool value)
    {
        lockCursor = value;
        if (lockCursor == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void UpdateCursorLock()
    {
        if (lockCursor == true)
        {
            InternalLockUpdate();
        }
    }

    private void InternalLockUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            m_cursorIsLocked = false;
            speedH = 0f;
            speedV = 0f;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_cursorIsLocked = true;
            speedH = 5f;
            speedV = 5f;
        }

        if (m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}