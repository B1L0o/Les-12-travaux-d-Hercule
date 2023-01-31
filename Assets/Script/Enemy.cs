using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float _seuilDistance;
    [SerializeField]
    protected float _speed;
    [SerializeField]
    protected int _health;
    protected int _index_next_target=0;
    protected Transform _target;
    protected GameObject _player;
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
            //enlever au player de la vie
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _target = _waypoints[0];
        transform.Rotate(0,180,0,Space.World);
    }
    protected virtual void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _speed * Time.deltaTime,Space.World);
        if (Vector3.Distance(transform.position,_target.position)<0.3f)
        {
            _index_next_target = (_index_next_target + 1) % _waypoints.Length;
            _target = _waypoints[_index_next_target];
            transform.Rotate(0,180,0,Space.World);
        }

    }
    protected abstract void Attack();
    
}
