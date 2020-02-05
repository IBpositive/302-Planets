using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// set a requirement
[RequireComponent(typeof(LineRenderer))]
public class Orbit : MonoBehaviour
{

    public Transform orbitCenter;
    public LineRenderer orbitPath;
    [Range(1, 10)] public float radius = 6;
    [Range(4, 32)] public int resolution = 8;

    // Start is called before the first frame update
    void Start()
    {
        orbitPath = GetComponent<LineRenderer>();
        orbitPath.loop = true;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = FindOrbitPoint(Time.time, radius);
        transform.position = pos;

        UpdatePoints();

    }

    private Vector3 FindOrbitPoint(float angle, float mag)
    {
        Vector3 pos = (orbitCenter == null) ? Vector3.zero : orbitCenter.position;

        pos.x += Mathf.Cos(angle) * mag;
        pos.z += Mathf.Sin(angle) * mag;
        return pos;
    }

    /// <summary>
    /// Set the points in the LineRenderer
    /// </summary>
    void UpdatePoints()
    {
        Vector3[] points = new Vector3[resolution];

        for(int i = 0; i < points.Length; i++)
        {
            float p = i / (float)points.Length;
            float radians = p * Mathf.PI * 2;
            points[i] = FindOrbitPoint(radians, radius);



        }
        orbitPath.positionCount = resolution;
        orbitPath.SetPositions(points);
    }



}
