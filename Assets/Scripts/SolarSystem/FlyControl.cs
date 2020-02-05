using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyControl : MonoBehaviour
{

    public float flySpeed = 10;
    float x;

    // Update is called once per frame
    void Update()
    {
        MovePoint();
    }

    void MovePoint()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * flySpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * flySpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * flySpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * flySpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += Vector3.up * flySpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.position += Vector3.down * flySpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            x += flySpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(x, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x -= flySpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(x, 0, 0);
        }
    }
}
