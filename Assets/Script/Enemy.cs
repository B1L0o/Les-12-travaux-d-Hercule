using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float _speed;
    [SerializeField]
    protected int _health;
    [SerializeField]
    protected GameObject _player;
    protected EnemyState _enemyState;
    [SerializeField]
    protected Transform[] _waypoints;

    
    protected void RemoveHealth(int Damage)
    {
        _health = _health - Damage;
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //enlever de la vie au Player
        }
        //else if (other.CompareTag("Weapon"))
        //{
        //Destroy(gameObject);
        //}
    }

    


    protected void SetState(EnemyState enemyState)
    {
        _enemyState = enemyState;
    }
    protected abstract void Attack();
    
}
