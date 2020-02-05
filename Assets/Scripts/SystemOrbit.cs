using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SystemOrbit : MonoBehaviour
{
    public LineRenderer orbitPath;
    float xSpread;
    float zSpread;
    float ySpread;
    float rotSpeed;
    float speedCache;
    bool rotateClockwise;


    public float xRangeMin;
    public float xRangeMax;
    public float zRangeMin;
    public float zRangeMax;
    public float yRangeMin = -5;
    public float yRangeMax = 5;
    public Transform centerPoint;
    public float rotSpeedMin = 0.5f;
    public float rotSpeedMax = 1;
    public bool isMoon;
    [Range(4, 32)] public int lineResolution = 10;

    float timer = 0;

    void Start()
    {
        xSpread = Random.Range(xRangeMin, xRangeMax);
        ySpread = Random.Range(yRangeMin, yRangeMax);
        zSpread = Random.Range(zRangeMin, zRangeMax);
        speedCache = Random.Range(rotSpeedMin, rotSpeedMax);
        rotSpeed = speedCache;
        rotateClockwise = (Random.value > 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        SpeedControl();

        // memory leak?
        timer += Time.deltaTime * rotSpeed;
        Rotate();
        transform.LookAt(centerPoint);

        //Vector3 pos = Rotate(xSpread, ySpread, zSpread, Time.time);
        //transform.position = pos;

        //Debug.Log(rotSpeed);
    }

    private void SpeedControl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotSpeed = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            rotSpeed = speedCache;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            rotSpeed = speedCache/2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            rotSpeed = speedCache;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            rotSpeed = speedCache*2;
        }
    }



    void Rotate()
    {
        if (rotateClockwise)
        {
            // -mathf.cos makes it move clockwise, positive means counterclockwise
            float x = -Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            float y = Mathf.Sin(timer) * ySpread;
            Vector3 pos = new Vector3(x, y, z);
            transform.position = pos + centerPoint.position;
        } else
        {
            float x = Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            float y = Mathf.Sin(timer) * ySpread;
            Vector3 pos = new Vector3(x, y, z);
            transform.position = pos + centerPoint.position;
        }
        //Debug.Log(timer);
    }



    private Vector3 Rotate(float xAxis, float yAxis, float zAxis, float t)
    {
        Vector3 pos = (centerPoint == null) ? Vector3.zero : centerPoint.position;
        if (rotateClockwise)
        {
            // -mathf.cos makes it move clockwise, positive means counterclockwise
            pos.x = -Mathf.Cos(t) * xAxis;
            pos.z = Mathf.Sin(t) * zAxis;
            pos.y = Mathf.Sin(t) * yAxis;
            //transform.position = pos + centerPoint.position;
        }
        else
        {
            pos.x = Mathf.Cos(t) * xAxis;
            pos.z = Mathf.Sin(t) * zAxis;
            pos.y = Mathf.Sin(t) * yAxis;
            //transform.position = pos + centerPoint.position;
        }

        return pos;
        //Debug.Log(timer);
    }

    void UpdatePoints()
    {
        Vector3[] points = new Vector3[lineResolution];

        for (int i = 0; i < points.Length; i++)
        {
            float p = i / (float)points.Length;
            float radians = p * Mathf.PI * 2;
            points[i] = Rotate(xSpread, ySpread, zSpread, radians);



        }
        orbitPath.positionCount = lineResolution;
        orbitPath.SetPositions(points);
    }

}




