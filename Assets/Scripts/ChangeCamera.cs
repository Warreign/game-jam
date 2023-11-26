using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeCamera : MonoBehaviour
{
    public int currentCam = 0;
    public int maxCamNum;

    [Serializable]
    public struct Cam
    {
        public GameObject camera;
    }

    public List<Cam> cameras;
    // Start is called before the first frame update
    void Start()
    {
        maxCamNum = cameras.Count - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right"))
        {
            cameras[currentCam].camera.SetActive(false);
            currentCam = currentCam+1 > maxCamNum ? 0 : currentCam+1;
            cameras[currentCam].camera.SetActive(true);
        }
        if (Input.GetKeyDown("left"))
        {
            cameras[currentCam].camera.SetActive(false);
            currentCam = currentCam - 1 < 0 ? maxCamNum : currentCam - 1;
            cameras[currentCam].camera.SetActive(true);
        }
    }
}
