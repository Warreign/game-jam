using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public bool destroyed = false;
    public bool isBarrel;
    public GameObject destroyedPath;

    public GameManager manager;

    [Serializable]
    public struct BlowObject
    {
        public GameObject obj;
        public Enemy enemy;
    }
    public List<BlowObject> blowObjNear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void destroyE()
    {
        Debug.Log("Destroyed " + this.gameObject.name);

        destroyed = true;
        destroyedPath.gameObject.SetActive(true);
        this.gameObject.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
