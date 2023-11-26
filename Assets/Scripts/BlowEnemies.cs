using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static Enemy;

public class BlowEnemies : MonoBehaviour
{
    public float blowRadius = 10f;

    public GameManager manager;

    public List<BlowObject> blowObjs;

    public void blow(Vector2 pos)
    {
        foreach (var blowObj in blowObjs)
        {
            if (blowObj.enemy.destroyed != true && Vector2.Distance(pos, new Vector2(blowObj.obj.transform.position.x, blowObj.obj.transform.position.z)) < blowRadius)
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
            manager.decreaseTargets();
            //blowNear(blowObj);
        }
    }
}
