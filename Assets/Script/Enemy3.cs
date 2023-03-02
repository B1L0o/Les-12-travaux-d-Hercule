using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    private bool canShoot;
    public Transform firePos;
    public GameObject bullet;
    private Animator _animator;

    protected void Update()
    {
        if (_player.transform.position.x>=transform.position.x&&  Mathf.Abs(_player.transform.position.y-transform.position.y)     <1&&canShoot)
        {
            _animator.Play("ennemi3_shoot", -1, 0f); 
            Attack();
        }
    }

    protected void Shoot()
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
       
        StartCoroutine(Attack_Coroutine());
        IEnumerator Attack_Coroutine()
        {
            canShoot = false;
            yield return new WaitForSeconds(10);
            canShoot = true;
        }
    }
}
