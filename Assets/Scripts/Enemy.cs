using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : LivingEntity
{
    //Transform target;
    protected override void Start()
    {
        base.Start();
        //target = GameObject.FindGameObjectWithTag ("Player").transform;
    }
}

