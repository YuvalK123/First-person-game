using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonActivate : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
    	if(other.tag == "Player"){
    		NavigationAI.canAttack = true;
    		this.gameObject.GetComponent<BoxCollider>().enabled = false;
    		Destroy(this);
    	}
    }
}
