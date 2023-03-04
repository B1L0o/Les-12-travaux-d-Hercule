using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    protected void Start()
    {
        SetState(new Patrol(_waypoints,_speed,gameObject,_player));
        _enemyState.InitialiseState();
    }

    protected void Update()
    {
        _enemyState.ApplyState();
    }

    protected new void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }

    protected override void Attack()
    {
        throw new NotImplementedException();
    }
}


