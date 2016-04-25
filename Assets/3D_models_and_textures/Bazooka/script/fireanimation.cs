using UnityEngine;
using System.Collections;

public class fireanimation : StateMachineBehaviour 
{

	// OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		if(Input.GetButtonDown("Fire1"))
		{

				animator.SetTrigger("Shoot");

		} 
	}
}
