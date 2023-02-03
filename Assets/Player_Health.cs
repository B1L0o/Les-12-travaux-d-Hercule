using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    private float health;
    private float maxHealth;

    // Update is called once per frame
    void Start()
    { 
        health = maxHealth;
    }

    public void TakeDamage(float _damage)
    {
        health -= _damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}