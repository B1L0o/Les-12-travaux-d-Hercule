using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lion_Walk : StateMachineBehaviour
{
    private EnemyState _enemyState;
    private Vector3 _playerPosition;
    private Vector3 lionPosition;
    private List<Vector3> path;

    private int AttackRange;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyState = animator.GetComponent<Lion>().GetEnemyState();
        path = ((FollowPlayer)_enemyState).path;
        lionPosition = animator.GetComponent<Transform>().position;
        _playerPosition =  animator.GetComponent<Lion>().GetPlayerPosition();
        AttackRange = animator.GetComponent<Lion>().GetAttackRange();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        path = ((FollowPlayer)_enemyState).path;
        if (Vector3.Distance(lionPosition,_playerPosition)<=AttackRange)
        {
            animator.SetTrigger("Attack");
        }
        
        if (path != null && path.Count>=2 && Mathf.Abs(path[1].y - path[0].y) >=1)
        {
            animator.SetTrigger("Jump");
        }
        _enemyState.ApplyState();   
        
        
        
        
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Jump");
        animator.ResetTrigger("Attack");
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
