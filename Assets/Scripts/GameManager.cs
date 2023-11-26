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

    public TextMeshProUGUI xField;
    public TextMeshProUGUI yField;

    public int targetsLeft = 0;
    public int health = 100;


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

}