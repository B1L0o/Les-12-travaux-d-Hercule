using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lion2 : Enemy
{
    private bool isInvulnerable;
    [SerializeField] 
    private GameObject attackCollider;
    [SerializeField]
    private Slider slider;
    public AudioManager AudioManager;
    
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    private void Start()
    {
        isInvulnerable = false;
        SetMaxHealth(_health);
        AudioManager.Play("BossFightMusic");
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
                Damage = Damage * 2;
                SetIsInvulnerable(true);
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
        VictoryManager.instance.WhenBossDeath();
        Destroy(gameObject);
    }
    public bool isInAttackCollider()
    {
        Collider2D coll =  attackCollider.GetComponent<Collider2D>();
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
    protected void AttackSkill()
    {
        if (isInAttackCollider())
        {
            StartCoroutine(_player.TakeDMG(Damage));
        }
        
    }
}