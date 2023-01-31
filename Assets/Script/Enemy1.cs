using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    protected new void Start()
    {
        base.Start();
    }

    protected new void Update()
    {
        base.Update();
    }
    protected override void Attack()
    {
        throw new NotImplementedException();
    }
}


