using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state : StateMachineBehaviour {

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetInteger("state", animator.GetInteger("next"));
	}
}
