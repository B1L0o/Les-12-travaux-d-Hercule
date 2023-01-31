using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy2 : Enemy
{
    protected new void Start()
    {
        base.Start();
    }
    protected new void Update()
    {
        float distance = Vector3.Distance (transform.position, _player.transform.position); 
        if (distance<_seuilDistance && distance>1) 
        {
            Attack();
        }
        else
        {
            base.Update();
        }
            
        
    }

    
    protected override void Attack()
    {
        transform.position = Vector3.MoveTowards( transform.position,_player.transform.position,_speed*Time.deltaTime);
    }
}
