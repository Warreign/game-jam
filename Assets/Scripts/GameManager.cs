using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public DroneController droneController;
    public Camera mainCamera;

    public YourExistingScript explosionCaster;

    public int currentX = 0;
    public int currentY = 0;

    public int ammo;
    public int health = 100;

    List<GameObject> islandTargets;

    public GameObject island;
    public Transform islandPos;
    public TextMeshProUGUI xField;
    public TextMeshProUGUI yField;

    public TextMeshProUGUI targetsLeftField;

    public BlowEnemies blowController;

    public GameObject bohdana;

    public TextMeshProUGUI leftAmmoField;

    public TextMeshProUGUI healthField;

    public int targetsLeft = 6;


    // Start is called before the first frame update
    void Start()
    {
        // foreach (Transform child in island.)
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
        targetsLeftField.text = Math.Max(targetsLeft, 0).ToString();
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
        bohdana.SetActive(mainCamera.enabled);
        mainCamera.enabled = !mainCamera.enabled;
    }

    public void fire()
    {
        Debug.Log(island.transform.position);

        Debug.Log("X: " + currentX + ", Y: " + currentY);
        explosionCaster.StartExplosion(currentY*10, -100 + currentX*10);

        ammo--;

        blowController.blow(new Vector2(currentY*10, -100 + currentX*10));

        if (ammo == 0 && targetsLeft > 0)
        {
            gameOver();
        }
        else if (targetsLeft <= 0)
        {
            win();
        }
    }

    public void gameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void win()
    {
        SceneManager.LoadScene("WinOver");

    }


    public void decreaseTargets()
    {
        targetsLeft--;   
    }
}