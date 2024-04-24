using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossWalkTowardWay : StateMachineBehaviour
{

    private NavMeshAgent agent;
    private int wayPointState = 1;
    private Transform wayPoint;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        wayPointState++;
        if (wayPointState > 3) wayPointState = 1;

        if (wayPointState == 1)
        {
            wayPoint = GameObject.FindGameObjectWithTag("Waypoint1").transform;
        }

        if (wayPointState == 2)
        {
            wayPoint = GameObject.FindGameObjectWithTag("Waypoint2").transform;
        }

        if (wayPointState == 3)
        {
            wayPoint = GameObject.FindGameObjectWithTag("Waypoint3").transform;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(wayPoint.position);

        if (agent.remainingDistance < 1 && agent.remainingDistance > 0.01f)
        {
            animator.SetTrigger("Idle");
        }
        
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Idle"); 
    }

    

}
