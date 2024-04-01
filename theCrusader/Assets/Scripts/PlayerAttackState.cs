using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttackState : StateMachineBehaviour
{
    NavMeshAgent _agent;
    AttackController attackController;

    public string _tag;
    public float stopAttackingDistance = 2.2f;
    public float timer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackController = animator.GetComponent<AttackController>();
        _agent = animator.GetComponent<NavMeshAgent>();

        _tag = animator.tag;
        timer = 2.5f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(attackController.targetToAttack != null)
        {
            LookAtTarget();

            ////keep follow enemy
            //_agent.SetDestination(attackController.targetToAttack.position);

            ////still attack?
            //float distanceFromTarget = Vector3.Distance(attackController.targetToAttack.position, animator.transform.position);
            //if (distanceFromTarget > stopAttackingDistance || attackController.targetToAttack == null)
            //{
            //    animator.SetBool("IsAttack", false);
            //}
            timer -= Time.deltaTime;
            
            if(_tag == "Enemy" && timer < 0)
            {
                animator.SetBool("IsDead", true);
            }
        }
    }

    private void LookAtTarget()
    {
        Vector3 direction = attackController.targetToAttack.position - _agent.transform.position;
        _agent.transform.rotation = Quaternion.LookRotation(direction);

        var yRotation = _agent.transform.eulerAngles.y;
        _agent.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
