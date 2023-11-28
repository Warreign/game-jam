using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCamera : MonoBehaviour
{

    public Vector3 target;
    public float elevation;
    public float radius;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        float t = Time.time * speed;
        float x = Mathf.Sin(t);
        float z = Mathf.Cos(t);

        transform.position = new Vector3(x*radius + target.x, elevation + target.y, z*radius + target.z);
        transform.LookAt(target);
    }

    void OnValidate()
    {
        Debug.Log("Current target: " + target);
    }
}
