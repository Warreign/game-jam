using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DroneController : MonoBehaviour
{
    public int currentDrone = 0;
    private bool active = false;

    [Serializable]
    public struct Cam
    {
        public GameObject camera;
    }

    public void toggle()
    {
        drones[currentDrone].SetActive(!active);
        active = !active;        
    }

    public List<GameObject> drones;

    IEnumerator waiterR()
    {
        Debug.Log("Waiter_g");
        yield return new WaitForSecondsRealtime(1);
        drones[currentDrone].SetActive(false);
        // currentCam = currentCam + 1 > maxCamNum ? 0 : currentCam + 1;
        currentDrone = (currentDrone + 1) % drones.Count;
        drones[currentDrone].SetActive(true);
    }

    IEnumerator waiterL()
    {
        Debug.Log("Waiter_g");
        yield return new WaitForSecondsRealtime(1);
        drones[currentDrone].SetActive(false);
        // currentCam = currentCam - 1 < 0 ? maxCamNum : currentCam - 1;
        currentDrone = (currentDrone - 1) % drones.Count;

        drones[currentDrone].SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            drones.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (Input.GetKeyDown("right"))
            {
                StartCoroutine(waiterR());
            }
            if (Input.GetKeyDown("left"))
            {
                StartCoroutine(waiterL());
            }
        }
    }
}