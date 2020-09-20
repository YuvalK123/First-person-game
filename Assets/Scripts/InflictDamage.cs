using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class InflictDamage : MonoBehaviour
{
	public int damageAmount = 5;
	public float targetDistance;
	public float allowedRange = 3.1f;

	public static void Damage(GameObject comp){
		RaycastHit hit;
	    if (Physics.Raycast(comp.transform.position, comp.transform.TransformDirection(Vector3.forward),out hit)){
		    float targettDistance = hit.distance;
		    if (targettDistance <= 3.1f){
		    	hit.transform.SendMessage("DeductPoints",5, SendMessageOptions.DontRequireReceiver);
		    }
	    }
	}

    // Update is called once per frame
    /*void Update()
    {
    	return;
        if (AxeSwing.holdingAxe){
        	if (Input.GetButtonDown("Fire1") && !AxeSwing.isSwinging){
	        	RaycastHit hit;
	        	if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit)){
	        		targetDistance = hit.distance;
	        		if (targetDistance <= allowedRange){
	        			hit.transform.SendMessage("DeductPoints",damageAmount, SendMessageOptions.DontRequireReceiver);
	        		}

	        	}
			}
        }
    }*/
}

