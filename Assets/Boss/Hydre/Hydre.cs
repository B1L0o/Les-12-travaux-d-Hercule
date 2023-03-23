using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydre : Enemy
{
    // Start is called before the first frame update
    private Shake shake;
    private int counter;
    private bool isInvulnerable;
    [SerializeField]
    private bool isRightOriented;
    [SerializeField] 
    private float attackRange;
    public AudioSource audioSource;
    public AudioClip groundBreak;
    public AudioClip bossFightMusic;
    void Start()
    {
        shake = GameObject.FindWithTag("ScreenShake").GetComponent<Shake>();
        counter = 0;
        isInvulnerable = true;
    }

    public void IncrementAnimationCounter()
    {
        GetComponent<Animator>().SetInteger("counter",counter+1);
    }
    public void SetIsInvulnerable(bool _isInvulnerable)
    {
        isInvulnerable = _isInvulnerable;
    }

    public void LookAtPlayer()
    {
        Vector3 scale = transform.localScale;
        if (_player.transform.position.x>transform.position.x)
        {
            if (isRightOriented)
            {
                scale.x = Math.Abs(scale.x);
            }
            else
            {
                scale.x = Math.Abs(scale.x)*-1;
            }
            
        }
        else
        {
            if (isRightOriented)
            {
                scale.x = Math.Abs(scale.x)*-1;
            }
            else
            {
                scale.x = Math.Abs(scale.x);
            }
        }

        transform.localScale = scale;

    }
    public override void TakeDamage(int damage)
    {
        if (isInvulnerable==false)
        {
            _health = _health - damage;
            if (_health<=250)
            {
                //Passer a la deuxième partie du combat de boss
            }
            if (_health<=0)
            {
                Die();
            }
        }
        
    }

    protected override void Die()
    {
        VictoryManager.instance.WhenBossDeath();
        Destroy(gameObject);
    }
    protected override void Attack()
    {
        Collider2D collider2DInfo = Physics2D.OverlapCircle(transform.position, attackRange);
        if (collider2DInfo != null)
        {
            StartCoroutine(_player.TakeDMG(Damage));
        }
    }

    public void Shake()
    {
        shake.camShake();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
