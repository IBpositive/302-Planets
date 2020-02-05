using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalCamera : MonoBehaviour
{

    public float yaw { get; private set; } // other scripts can get the value but cant set the value; // default is 0
    float pitch = 0;

    public float lookSensitivityX = 1;
    public float lookSensitivityY = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // needs to be cap and space
        float mouseX = Input.GetAxis("Mouse X"); // how many picels the mouse has moved left/right
        float mouseY = Input.GetAxis("Mouse Y"); // how many pixels the mouse has moved up/down

        yaw += mouseX * lookSensitivityX;
        pitch += mouseY * lookSensitivityY;

        pitch = Mathf.Clamp(pitch, 0, 89); // gates how far you can move the camera

        Quaternion targetRot = Quaternion.Euler(pitch, yaw, 0); // 0 is roll


        transform.rotation = AnimMath.Dampen(transform.rotation, targetRot, .001f);



    }
}
