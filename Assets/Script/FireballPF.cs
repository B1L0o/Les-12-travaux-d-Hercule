using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballPF : MonoBehaviour
{
    private GameObject _player;
    private EnemyState _enemyState;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private bool _DebugMode;
    [SerializeField]
    private int _width;
    [SerializeField]
    private int _height;
    [SerializeField]
    private GameObject explosionEffect;
    [SerializeField] 
    private int _groundy;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _enemyState =  new FollowPlayer(_width,_height,bulletSpeed,_DebugMode,_player,gameObject,transform,_groundy);
        _enemyState.InitialiseState();
    }

    private void Update()
    {
        _enemyState.ApplyState();
        GetComponent<SpriteRenderer>().flipX = !(GetComponent<SpriteRenderer>().flipX);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") || col.CompareTag("Tilemap"))
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
       
    }
}