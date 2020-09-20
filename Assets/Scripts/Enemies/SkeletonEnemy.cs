using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonEnemy : MonoBehaviour
{
	public int enemyHealth = 10;
    public GameObject attackObj; 

    void DeductPoints(int damageAmount){
    	enemyHealth -= damageAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0){
            NPCChat.skeletonSlayed = true;
        	this.GetComponent<Animator>().Play("Death");
            this.GetComponent<NavigationAI>().enabled = false;
            this.GetComponent<NavMeshAgent>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            attackObj.SetActive(false);        }
    }
}
