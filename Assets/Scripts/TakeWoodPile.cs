using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TakeWoodPile : MonoBehaviour
{
    public float desiredDistance = 4.1f;
	// the two text objects
	public GameObject ActionDisplay;
	public GameObject ActionText;
	public GameObject ExtraCursor;
    public GameObject woodPile;

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver(){
        float TheDistance = LayerCasting.DistanceFromTarget;
    	if (TheDistance <= desiredDistance){
    		ActionText.GetComponent<Text>().text = "Take Wood";

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
    	woodPile.SetActive(false);
        SetDisplayActive(false);
        NPCChoice.questComplete = true;
    	this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
    void SetDisplayActive(bool b){
    	ActionDisplay.SetActive(b);
    	ActionText.SetActive(b);
    	ExtraCursor.SetActive(b);
    }
}
