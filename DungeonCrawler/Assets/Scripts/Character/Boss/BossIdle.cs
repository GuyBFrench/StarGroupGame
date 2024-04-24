

using UnityEngine;

public class BossIdle : StateMachineBehaviour
{

    private float timer = 1.5f;
    

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger("WalkWay");
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("WalkWay");
        timer = 1.5f;
    }

    
    
}
