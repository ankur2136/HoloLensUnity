using UnityEngine;
using System.Collections;

public class firepooling : StateMachineBehaviour 
{
	public AudioClip shootClip;
	public GameObject bulletPrefab;
	public float shootForce;
	public int numShots = 50;

	Transform gun = null;
	GameObject[] bullets = null;
	const int maxPool = 1000;
	int currentBullet = 0;
	

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		if(gun == null)
			gun = animator.gameObject.transform.Find("arm_gun:Bip001 R UpperArm/arm_gun:Bip001 R Forearm/arm_gun:Bip001 R Hand/Bazooka1/Spawn"); // todo use full path for faster
	
		if(bullets == null)
		{
			bullets = new GameObject[maxPool];
			for(int i = 0; i < maxPool; i++)
			{
				bullets[i] = (GameObject)Instantiate(bulletPrefab);
				bullets[i].SetActive(false);
			}
		}

		for(int i = 0; i < numShots; i++)
		{
			//GameObject bullet = Instantiate(bulletPrefab, gun.position, gun.rotation) as GameObject;
			bullets[currentBullet].transform.position = gun.position;
			bullets[currentBullet].transform.rotation = gun.rotation;
			bullets[currentBullet].transform.Rotate(Random.Range(-15f, 15f), Random.Range(-15f, 15f), 0f);
			bullets[currentBullet].GetComponent<Rigidbody>().velocity = gun.TransformDirection(new Vector3(0,0,shootForce));
			bullets[currentBullet].SetActive(true);
			
			if(++currentBullet >= maxPool)
				currentBullet = 0;
		}

		//currently bug in Unity 5 RC1 
		//animator.GetComponent<AudioSource>().PlayOneShot(shootClip); 
		animator.GetComponent<AudioSource>().Play();
	}


}
