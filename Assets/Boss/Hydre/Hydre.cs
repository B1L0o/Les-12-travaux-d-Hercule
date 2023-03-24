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
    private GameObject skill1Collider;
    [SerializeField] 
    private float attackRange;
    public AudioSource audioSource;
    public AudioClip groundBreak;
    public AudioClip bossFightMusic;
    void Start()
    {
        audioSource.clip = GetComponent<Hydre>().groundBreak;
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

    public bool isInSkill1Collider()
    {
        Collider2D coll =  skill1Collider.GetComponent<Collider2D>();
        List<Collider2D> result = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D().NoFilter();
        int nb_collider = Physics2D.OverlapCollider(coll,filter,result);
        foreach (var collider in result)
        {
            if (collider.tag == "Player")
            {
                return true;
            }
        }

        return false;
    }

    protected override void Attack()
    {
        if (isInSkill1Collider())
        {
            StartCoroutine(_player.TakeDMG(Damage));
        }
        
    }

    public void PlayGroundBreakSound()
    {
        audioSource.Play();
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
