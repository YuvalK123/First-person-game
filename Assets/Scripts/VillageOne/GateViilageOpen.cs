using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateViilageOpen : MonoBehaviour
{

	public GameObject TheDoor;
	public AudioSource creakSound;

	void OnTriggerEnter(){
		creakSound.Play();
		Animator animator = TheDoor.GetComponent<Animator>();
		animator.enabled = true;
		animator.Play("VillageGateAnim");
		this.GetComponent<BoxCollider>().enabled = false;
	}

   
}
