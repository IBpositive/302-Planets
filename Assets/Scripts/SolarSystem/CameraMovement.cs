using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform star;
    public Transform planet1;
    public Transform planet2;
    public Transform planet3;
    public Transform planet4;
    public Transform planet5;
    public Transform moon1;
    public Transform moon2;
    public Transform moon3;
    public Transform moon4;
    public Transform moon5;
    public Transform moon6;
    public Transform moon7;
    public Transform moon8;
    public Transform flyCam;
    public Transform target;

    public float smoothSpeed = 100000f; //?????
    public Vector3 offset;
    Vector3 velocity = Vector3.one;

    // run after update
    void LateUpdate()
    {
        ChangeFocus();
        Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);

    }

    private void ChangeFocus()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                target = moon1.transform;
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                target = moon2.transform;
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                target = moon3.transform;
            }
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                target = moon4.transform;
            }
            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                target = moon5.transform;
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                target = moon6.transform;
            }
            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                target = moon7.transform;
            }
            if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                target = moon8.transform;
            }
        } else
        {
            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                target = star.transform;
            }
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                target = planet1.transform;
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                target = planet2.transform;
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                target = planet3.transform;
            }
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                target = planet4.transform;
            }
            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                target = planet5.transform;
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                target = flyCam.transform;
            }
        }

    }

}
