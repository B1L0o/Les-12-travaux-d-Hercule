using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3PF : Enemy
{
    private bool canShoot;
    public Transform firePos;
    public GameObject bullet;
    private Animator _animator;

    protected void Update()
    {
        if (canShoot&&_player.transform.position.x>=transform.position.x&&Mathf.Abs(_player.transform.position.y-transform.position.y)<1)
        {
           
            _animator.Play("ennemi3_shootPF", -1, 0f);
            canShoot = false;
        }
    }

    protected void ShootPF()
    {
        Instantiate(bullet,firePos.position,firePos.rotation);
    }
    
    protected void Start()
    {
        canShoot = true;
        _animator = GetComponent<Animator>();
    }
    
    protected override void Attack()
    {
        
    }
}