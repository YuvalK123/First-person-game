using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonAI : MonoBehaviour
{
    
    public GameObject theSkeleton;
    public int damageAmount = 50;
    public bool isAttacking = false;
    public AudioSource swordSwing;
    public AudioSource swordHit;


    void OnTriggerEnter(Collider other){
        if (other.tag == "Location" || other.tag != "Player"){
            return;
        }
        if(!isAttacking){
            theSkeleton.GetComponent<NavigationAI>().enabled = false;
            theSkeleton.GetComponent<NavMeshAgent>().enabled = false;
            Attack();
        }
    }

    void OnTriggerExit(Collider other){
    	Walk();
    	theSkeleton.GetComponent<NavigationAI>().enabled = true;	
        theSkeleton.GetComponent<NavMeshAgent>().enabled = true;
    }
    
	void Walk(){
    	theSkeleton.GetComponent<Animator>().Play("Walk");
    }
    void Idle(){
    	theSkeleton.GetComponent<Animator>().Play("Idle");
    }


    void Attack(){
        this.GetComponent<MeshCollider>().enabled = false;
        isAttacking = true;
        theSkeleton.GetComponent<Animator>().Play("Attack");
        StartCoroutine(TakeHealth());
    }

    IEnumerator TakeHealth(){
        yield return new WaitForSeconds(0.9f);
        swordSwing.Play();
        yield return new WaitForSeconds(0.1f);
        swordHit.Play();
        yield return new WaitForSeconds(0.2f);
        HealthMonitor.healthPoints -= damageAmount;
        //yield return new WaitForSeconds(0.1f);
        
        yield return new WaitForSeconds(1);
        isAttacking = false;
        Walk();
        theSkeleton.GetComponent<NavigationAI>().enabled = true;    
        theSkeleton.GetComponent<NavMeshAgent>().enabled = true;
        this.GetComponent<MeshCollider>().enabled = true;

    }
}
