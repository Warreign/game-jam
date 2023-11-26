using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public bool destroyed = false;
    public bool isBarrel;
    public string destroyedPath;

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
        destroyed = true;
        //TODO change texture to destroyed
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
