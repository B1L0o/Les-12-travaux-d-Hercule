using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : Enemy
{
    private bool isabletopatrol;
    [SerializeField] 
    private bool _DebugMode;
    [SerializeField] 
    private int _width;
    [SerializeField]
    private int _height;

    private float initialPlayerSpeed;
    [SerializeField] 
    private int _groundy;
    protected void Start()
    {
        isabletopatrol = true;
        SetState(new Patrol(_waypoints,_speed,gameObject,_player.gameObject));
        _enemyState.InitialiseState();
        initialPlayerSpeed = _player.moveSpeed;
    }
    protected void Update()
    {
        Attack();
        _enemyState.ApplyState();
        if ((_enemyState is Patrol||isabletopatrol==false) && _player.transform.position.x >= _waypoints[0].transform.position.x && _player.transform.position.x <= _waypoints[1].transform.position.x)
        {
            isabletopatrol = true;
            SetState(new FollowPlayer(_width,_height,_speed,_DebugMode,_player.gameObject,gameObject,_waypoints[0],_groundy));
            _enemyState.InitialiseState();
        }
        if (_enemyState is FollowPlayer &&(isabletopatrol==false || (_player.transform.position.x < _waypoints[0].transform.position.x||_player.transform.position.x > _waypoints[1].transform.position.x)))
        {
            if (isabletopatrol)
            {
                isabletopatrol = false;
                SetState(new FollowPlayer(_width,_height,_speed,_DebugMode,_waypoints[0].gameObject,gameObject,_waypoints[0],_groundy));
                _enemyState.InitialiseState();   
            }
            float distance = Vector3.Distance(transform.position,_waypoints[0].transform.position);
            if(distance<=1f)
            {
                SetState(new Patrol(_waypoints,_speed,gameObject,_player.gameObject));
                _enemyState.InitialiseState();
            }
            
        }
    }

    protected override void Attack()
    {
        if (CanAttack())
        {
            
            if (Time.time > lastAttackedTime + cooldown)
            {
                _player.moveSpeed = _player.moveSpeed - 40;
                Debug.Log(_player.moveSpeed);
                lastAttackedTime = Time.time;
            }
        }
    }
    
}
