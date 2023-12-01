using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static Enemy;

public class BlowEnemies : MonoBehaviour
{
    public float blowRadius = 100f;

    public GameManager manager;

    public List<BlowObject> blowObjs;

    public void blow(Vector2 pos)
    {
        foreach (var blowObj in blowObjs)
        {
            var dist = Vector2.Distance(pos, new Vector2(blowObj.obj.transform.position.x, blowObj.obj.transform.position.z));
            Debug.Log("Distance to " + blowObj.enemy.gameObject.name + " is " + dist);
            if (!blowObj.enemy.destroyed && dist < blowRadius)
            {
                Debug.Log("Destroying " + blowObj.enemy.gameObject.name);
                blowObj.enemy.destroyE();
                manager.decreaseTargets();
                if(blowObj.enemy.isBarrel)
                    blowNear(blowObj);
            }
        }
    }

    void blowNear(BlowObject blowObject)
    {
        foreach (var blowObj in blowObject.enemy.blowObjNear)
        {
            blowObj.enemy.destroyE();
            manager.decreaseTargets();
            //blowNear(blowObj);
        }
    }
}
