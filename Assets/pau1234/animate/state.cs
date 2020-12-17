using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state : StateMachineBehaviour {
    public bool haveNext;
    public int next;
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetInteger("state", animator.GetInteger("next"));
        if (haveNext)
        {
            animator.SetInteger("next", next);
        }
    }
}
