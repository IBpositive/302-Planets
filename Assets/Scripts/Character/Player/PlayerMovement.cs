using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5;

    public OrbitalCamera theCam;

    CharacterController body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if((v != 0 || h != 0) && theCam != null)
        {
            Quaternion targetRt = Quaternion.Euler(0, theCam.yaw, 0);
            transform.rotation = AnimMath.Dampen(transform.rotation, targetRt, .01f);
        }

        Vector3 moveDis = transform.forward += transform.forward * v * moveSpeed; // * Time.deltaTime;
        moveDis += transform.right * h * moveSpeed; // how far to move side-to-side
        body.SimpleMove(moveDis); // simple move (we think) does deltatime for you



    }
}
