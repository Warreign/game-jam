using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{

    public DroneController droneController;
    public Camera mainCamera;

    public int currentX = 0;
    public int currentY = 0;

    public int ammo = 5;
    public int health = 100;

    public TextMeshProUGUI xField;
    public TextMeshProUGUI yField;

    public TextMeshProUGUI targetsLeftField;

    public TextMeshProUGUI leftAmmoField;

    public TextMeshProUGUI healthField;

    public int targetsLeft = 0;


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
            // droneController.gameObject.SetActive(droneController.enabled);
            droneController.toggle();
        }

        xField.text = currentX.ToString();
        yField.text = currentY.ToString();
        healthField.text = health.ToString();
        leftAmmoField.text = ammo.ToString();
        targetsLeftField.text = targetsLeft.ToString();
    }

    public void increaseX()
    {
        currentX++;
    }

    public void increaseY()
    {
        currentY++;
    }

    public void decreaseX()
    {
        currentX--;
    }

    public void decreaseY()
    {
        currentY--;
    }

    public void enterDroneMode()
    {
        droneController.toggle();
    }

    public void enterDriveMode()
    { 

    }

    public void fire()
    {

    }


}