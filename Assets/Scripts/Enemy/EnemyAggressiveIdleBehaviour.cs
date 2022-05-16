using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAggressiveIdleBehaviour : StateMachineBehaviour
{
    private GameObject player;
    private NavMeshAgent agent;
    private EnemyController enemyController;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindWithTag("Player");
        agent = animator.gameObject.transform.parent.GetComponent<NavMeshAgent>();
        enemyController = animator.gameObject.transform.parent.GetComponent<EnemyController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.transform.parent.LookAt(player.transform);

        if (Vector3.Distance(animator.gameObject.transform.position, player.transform.position) > agent.stoppingDistance)
        {
            animator.SetBool("movingTowardsPlayer", true);
        } else
        {
            if (enemyController.CanAttack())
            {
                animator.SetTrigger("attack");
                enemyController.AttackPerformed();
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
