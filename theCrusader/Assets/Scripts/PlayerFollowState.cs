using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFollowState : StateMachineBehaviour
{
    AttackController attackController;
    NavMeshAgent _agent;
    public float attackingDistance = 2f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackController = animator.transform.GetComponent<AttackController>();
        _agent = animator.transform.GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //transition to idle?
        if(attackController.targetToAttack == null)
        {
            animator.SetBool("IsFollow", false);
        }

        //move to enemy
        _agent.SetDestination(attackController.targetToAttack.position);
        animator.transform.LookAt(attackController.targetToAttack);

        //transition to attack?
        float distanceFromTarget = Vector3.Distance(attackController.targetToAttack.position, animator.transform.position);
        if (distanceFromTarget < attackingDistance)
        {
            _agent.SetDestination(animator.transform.position);
            animator.SetBool("IsAttack", true);

        }

    }

}
