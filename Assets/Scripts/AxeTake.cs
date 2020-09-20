using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AxeTake : MonoBehaviour
{
 // going to be the actual distance from player casting script;
	public float TheDistance;
	// the two text objects
	public GameObject ActionDisplay;
	public GameObject ActionText;
	public GameObject ExtraCursor;
	public GameObject RealAxe;
	public GameObject FakeAxe;

    // Update is called once per frame
    void Update()
    {
        TheDistance = LayerCasting.DistanceFromTarget;

    }

    void OnMouseOver(){
    	if (TheDistance <= 4){
    		ActionText.GetComponent<Text>().text = "Take Axe";

    		SetDisplayActive(true);
    		if (Input.GetButtonDown("Action")){
    			Take();
    		}
    	}
    	else{
    		ActionText.GetComponent<Text>().text = "";
    		SetDisplayActive(false);
    	}
    }

    void OnMouseExit(){
    	ActionText.GetComponent<Text>().text = "";
    	SetDisplayActive(false);
    }

    void Take(){
    	ActionText.GetComponent<Text>().text = "";
    	RealAxe.SetActive(true);
    	FakeAxe.SetActive(false);
    	AxeSwing.holdingAxe = true;
    	SetDisplayActive(false);
        DialougeState.stateAxeTake = true;
    	Destroy(FakeAxe);
    	Destroy(gameObject);
    }
    void SetDisplayActive(bool b){
    	ActionDisplay.SetActive(b);
    	ActionText.SetActive(b);
    	ExtraCursor.SetActive(b);
    }
}
