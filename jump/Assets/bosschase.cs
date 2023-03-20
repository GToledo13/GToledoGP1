using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosschase : StateMachineBehaviour
{
   

   
    Transform player;
    Rigidbody2D rb;
    bossBehavior BOSS1;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        BOSS1 = animator.GetComponent<bossBehavior>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(player.position.x , rb.position.y);
         Vector2 newPos= Vector2.MoveTowards(rb.position, target, BOSS1.speed * Time.deltaTime);

        rb.MovePosition(newPos);

        float distance = Vector2.Distance(player.position, rb.position);
        if (distance < BOSS1.attackRange && !BOSS1.Phase2 && !BOSS1.Phase3 && !BOSS1.death)
        {
            animator.SetTrigger("MeleeAttack");
        }
        else if (distance < BOSS1.attackRange && BOSS1.Phase2 && !BOSS1.Phase3 && !BOSS1.death)
        {
            animator.SetTrigger("Phase2Attack");
        }
        else if (distance < BOSS1.attackRange && !BOSS1.Phase2 && BOSS1.Phase3 && !BOSS1.death)
        {
            animator.SetTrigger("Phase3Attack");
        }
        else if (distance < BOSS1.attackRange && BOSS1!.death)
        {
            animator.SetTrigger("Death");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    
}
