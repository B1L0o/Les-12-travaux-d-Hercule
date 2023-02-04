using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    private bool canShoot;
    public Transform firePos;
    public GameObject bullet;

    protected void Update()
    {
        float distance = Vector3.Distance (transform.position, _player.transform.position);
        if (distance<_seuilDistance && canShoot)
        {
           Attack();
        }
    }
    
    protected void Start()
    {
        _player = GameObject.FindWithTag("Player");
        canShoot = true;
    }

    protected override void Attack()
    {
        StartCoroutine(Attack_Coroutine());
        IEnumerator Attack_Coroutine()
        {
            Instantiate(bullet,firePos.position,firePos.rotation);
            canShoot = false;
            yield return new WaitForSeconds(10);
            canShoot = true;
        }
    }
}
