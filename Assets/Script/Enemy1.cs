using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    protected void Start()
    {
        SetState(new Patrol(_waypoints,_speed,gameObject,_player.gameObject));
        _enemyState.InitialiseState();
    }

    protected void Update()
    {
        _enemyState.ApplyState();
        Attack();
    }
    

    

   
}


