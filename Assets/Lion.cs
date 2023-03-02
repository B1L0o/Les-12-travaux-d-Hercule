using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion : Enemy
{
    [SerializeField] 
    private bool _DebugMode;
    [SerializeField] 
    private int _width;
    [SerializeField]
    private int _height;

    [SerializeField] 
    private int _groundy;
    // Start is called before the first frame update
    void Start()
    {
        SetState(new FollowPlayer(_width,_height,_speed,_DebugMode,_player,gameObject,transform,_groundy));
        _enemyState.InitialiseState();
    }

    public void Move()
    {
        _enemyState.ApplyState();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }
}
