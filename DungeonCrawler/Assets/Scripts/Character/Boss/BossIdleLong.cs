
using UnityEngine;

public class BossIdleLong : StateMachineBehaviour
{
    private float timer = 4;




    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger("WalkPlay");
        }

        else
        {
            timer -= Time.deltaTime;
        }
    }
    
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("WalkPlay");
        timer = 4;
    }

    
}
