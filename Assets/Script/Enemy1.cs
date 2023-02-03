using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    //protected new void Start()
    //{
    //base.Start();
    //}

    //protected new void Update()
//{
    //base.Update();
    //}

    protected void Start()
    {
        SetState(new Patrol(_waypoints,_speed,gameObject,_player));
        _enemyState.InitialiseState();
    }

    protected void Update()
    {
        _enemyState.ApplyState();
    }

    protected override void Attack()
    {
        throw new NotImplementedException();
    }
}


