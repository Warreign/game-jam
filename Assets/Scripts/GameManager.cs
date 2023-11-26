using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    public DroneController droneController;
    public Camera mainCamera;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("f"))
        {
            mainCamera.enabled = !mainCamera.enabled;
            droneController.gameObject.SetActive(droneController.enabled);
            droneController.toggle();
        }
    }
}