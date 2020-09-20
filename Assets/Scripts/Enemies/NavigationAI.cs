using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationAI : MonoBehaviour
{
	public GameObject theDestination;
	NavMeshAgent theAgent;
    public static bool canAttack = false;
    public GameObject thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack){
            theAgent.SetDestination(thePlayer.transform.position);
            return;
        }
    	//the player is the destination
        theAgent.SetDestination(theDestination.transform.position);
    }
}
