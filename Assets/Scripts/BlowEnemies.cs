using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static Enemy;

public class BlowEnemies : MonoBehaviour
{
    public float blowRadius = 10f;

    public List<BlowObject> blowObjs;

    public void blow(Vector3 pos)
    {
        foreach (var blowObj in blowObjs)
        {
            if (blowObj.enemy.destroyed != true && Vector3.Distance(pos, blowObj.obj.transform.position) < blowRadius)
            {
                blowObj.enemy.destroyE();
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
            //blowNear(blowObj);
        }
    }
}
