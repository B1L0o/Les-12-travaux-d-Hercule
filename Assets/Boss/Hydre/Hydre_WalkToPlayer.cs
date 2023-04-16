using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydre_WalkToPlayer : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    private GameObject player;

    private Transform bossTransform;
    [SerializeField]
    private float speed;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Hydre>().SetIsInvulnerable(false);
        bossTransform = animator.GetComponent<Transform>();
        //player = GameObject.FindGameObjectWithTag("Player");
        player = animator.GetComponent<Hydre>()._player.gameObject;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Hydre>().LookAtPlayer();
        Vector2 target = new Vector2(player.transform.position.x, bossTransform.position.y);
        bossTransform.position = Vector2.MoveTowards(bossTransform.position, target, speed * Time.fixedDeltaTime);
        if (animator.GetComponent<Hydre>().isInSkill1Collider())
        {
            animator.SetBool("skill1",true);
        }
        
        else if (animator.GetComponent<Hydre>().isInSkill2Collider())
        {
            animator.SetTrigger("skill2");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("skill2");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
