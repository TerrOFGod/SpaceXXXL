using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform player;
    public Transform cam;

    public static bool cursorLocked = false;
    float rotationX = 0;
    public float rotationSpeedHor = 5.0f;
    public float rotationSpeedVer = 5.0f;

    public float maxVert = 45.0f;
    public float minVert = -45.0f;

    private void Update()
    {
        SetX();
        SetY();
        UpdateCursorLock();
    }

    void SetX()
    {
        float rotationY = Input.GetAxis("Mouse X") * rotationSpeedHor * Time.deltaTime;
        player.transform.Rotate(0, rotationY, 0);
    }
    void SetY()
    {
        rotationX -= Input.GetAxis("Mouse Y") * rotationSpeedVer * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, minVert, maxVert);
        cam.transform.localEulerAngles = new Vector3(rotationX, 0, 0);
    }

    void UpdateCursorLock()
    {
        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = false;
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = true;
            }
        }
    }
}

