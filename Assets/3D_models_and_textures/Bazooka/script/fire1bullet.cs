using UnityEngine;
using System.Collections;

public class fire1bullet : StateMachineBehaviour 
{
	public AudioClip shootClip;
	public GameObject bulletprefab;
	public float shootForce;


	Transform gun = null;

	

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		if(gun == null)
			gun = animator.gameObject.transform.Find("arm_gun:Bip001 R UpperArm/arm_gun:Bip001 R Forearm/arm_gun:Bip001 R Hand/Bazooka1/Spawn"); // todo use full path for faster
	
		// instantiat 1 bullet

		var Bullet2 = (GameObject)Instantiate(bulletprefab, gun.position , gun.rotation);
		Bullet2.GetComponent<Rigidbody>().velocity = gun.TransformDirection(new Vector3 (0,0,shootForce));
	
		animator.GetComponent<AudioSource>().Play();
	}


}
