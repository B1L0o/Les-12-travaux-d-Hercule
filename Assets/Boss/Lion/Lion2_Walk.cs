using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion2_Walk : StateMachineBehaviour
{
    private Lion2 lion;
    private GameObject player;
    private Transform bossTransform;
    [SerializeField]
    private float speed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lion = animator.GetComponent<Lion2>();
        lion.SetIsInvulnerable(false);
        bossTransform = animator.GetComponent<Transform>();
        player = lion._player.gameObject;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lion.LookAtPlayer();
        Vector2 target = new Vector2(player.transform.position.x, bossTransform.position.y);
        bossTransform.position = Vector2.MoveTowards(bossTransform.position, target, speed * Time.fixedDeltaTime);
        if (lion.isInAttackCollider())
        {
            animator.SetBool("attack",true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}