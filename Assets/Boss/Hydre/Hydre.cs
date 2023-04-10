using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hydre : Enemy
{
    private Shake shake;
    private int counter;
    private bool isInvulnerable;
    
    [SerializeField] 
    private GameObject skill1Collider;
    [SerializeField]
    private GameObject skill2Collider;
    [SerializeField]
    private int DamageSkill2;
    [SerializeField]
    private Slider slider;

    public AudioManager AudioManager;
    void Start()
    {
        shake = GameObject.FindWithTag("ScreenShake").GetComponent<Shake>();
        counter = 0;
        isInvulnerable = true;
        SetMaxHealth(_health);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void IncrementAnimationCounter()
    {
        GetComponent<Animator>().SetInteger("counter",counter+1);
    }
    public void SetIsInvulnerable(bool _isInvulnerable)
    {
        isInvulnerable = _isInvulnerable;
    }

    
    public override void TakeDamage(int damage)
    {
        if (isInvulnerable==false)
        {
            _health = _health - damage;
            SetHealth(_health);
            if (_health<=2000 && GetComponent<Animator>().GetBool("IsEnraged")==false)
            {
                counter = 0;
                Damage = Damage * 2;
                DamageSkill2 = DamageSkill2 * 2;
                GetComponent<Animator>().SetInteger("counter",0);
                GetComponent<Animator>().SetBool("IsEnraged",true);
            }
            if (_health<=0)
            {
                AudioManager.Pause("BossFightMusic");
                Die();
            }
        }
        
    }

    protected override void Die()
    {
        GetComponent<Animator>().SetTrigger("dead");
        //VictoryManager.instance.WhenBossDeath();
        //Destroy(gameObject);
    }

    public void TriggerVictory()
    {
        VictoryManager.instance.WhenBossDeath();
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
    public bool isInSkill2Collider()
    {
        Collider2D coll =  skill2Collider.GetComponent<Collider2D>();
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

    protected void Attack()
    {
        if (isInSkill1Collider())
        {
            StartCoroutine(_player.TakeDMG(Damage));
        }
        
    }
    public void AttackSkill2()
    {
        if (isInSkill2Collider())
        {
            StartCoroutine(_player.TakeDMG(DamageSkill2));
        }

    }

    public void PlayGroundBreakSound()
    {
        AudioManager.Play("GroundShake");
    }

    

    public void PlayHydreScream()
    {
        AudioManager.Pause("BossFightMusic");
        AudioManager.Play("HydreScream");
    }

    public void WalkShake()
    {
        shake.bossWalkCamShake();
    }
    public void ScreamShake()
    {
        shake.bossScreamCamShake();
    }

}
