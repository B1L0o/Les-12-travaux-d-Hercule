using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    
    public abstract void InitialiseState();
    public abstract void ApplyState();

}

public class Patrol : EnemyState
{
    protected Transform[] _waypoints;
    protected int _index_next_target=0;
    protected Transform _target;
    protected GameObject _player;
    protected GameObject _ennemy;
    protected float _speed;
    
    public Patrol(Transform[] waypoint,float speed, GameObject ennemy, GameObject player)
    {
        _waypoints = waypoint;
        _speed = speed;
        _ennemy = ennemy;
        _player = player;


    }
    public override void InitialiseState()
    {
        _target = _waypoints[0];
        _ennemy.transform.Rotate(0,180,0,Space.World);
    }

    public override void ApplyState()
    {
        Vector3 direction = _target.position - _ennemy.transform.position;
        _ennemy.transform.Translate(direction.normalized * _speed * Time.deltaTime,Space.World);
        if (Vector3.Distance(_ennemy.transform.position,_target.position)<0.3f)
        {
            _index_next_target = (_index_next_target + 1) % _waypoints.Length;
            _target = _waypoints[_index_next_target];
            _ennemy.transform.Rotate(0,180,0,Space.World);
        }
    }
}

public class FollowPlayer : EnemyState
{
    public override void InitialiseState()
    {
        throw new NotImplementedException();
    }

    public override void ApplyState()
    {
        throw new NotImplementedException();
    }
}
