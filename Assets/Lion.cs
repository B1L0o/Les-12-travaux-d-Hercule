using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : Enemy
{
    private bool IsInvulnerable;
    [SerializeField] 
    private bool _DebugMode;
    [SerializeField] 
    private int _width;
    [SerializeField]
    private int _height;
    [SerializeField] 
    private int AttackRange;

    [SerializeField] 
    private int _groundy;
    // Start is called before the first frame update
    void Start()
    {
        IsInvulnerable = false;
        SetState(new FollowPlayer(_width,_height,_speed,_DebugMode,_player,gameObject,_waypoints[0],_groundy));
        _enemyState.InitialiseState();
    }

    public void Jump()
    {
        transform.position +=  (2.7f*Vector3.up)  * _speed * Time.deltaTime;
    }
    public EnemyState GetEnemyState()
    {
        return _enemyState;
    }

    public void SetEnemyState(float speed)
    {
        SetState(new FollowPlayer(_width,_height,speed,_DebugMode,_player,gameObject,_waypoints[0],_groundy));
        _enemyState.InitialiseState();
    }

    public void SetAttackRange(int attackrange)
    {
        AttackRange = attackrange;
    }

    public void SetIsInvulnerable(bool isInvulnerable)
    {
        IsInvulnerable = isInvulnerable;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public int GetAttackRange()
    {
        return AttackRange;
    }
    public Vector3 GetPlayerPosition()
    {
        return _player.transform.position;
    }

    public void TakeDamage(int damage)
    {
        if (IsInvulnerable==false)
        {
            _health = _height - damage;

            if (_health<=50)
            {
                GetComponent<Animator>().SetBool("IsEnraged",true);
            }
            if (_health<=0)
            {
                Die();
            }
        }
        
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    
    protected override void Attack()
    {
        Collider2D collider2DInfo = Physics2D.OverlapCircle(transform.position, AttackRange);
        if (collider2DInfo != null)
        {
            Debug.Log("OUCH player");
        }
    }
    
}
