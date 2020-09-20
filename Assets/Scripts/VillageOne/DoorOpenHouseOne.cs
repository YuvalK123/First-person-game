using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenHouseOne : MonoBehaviour
{

	public GameObject TheDoor;
	public AudioSource creakSound;

	void OnTriggerEnter(){
		creakSound.Play();
		Animator animator = TheDoor.GetComponent<Animator>();
		animator.enabled = true;
		animator.Play("OpenDoorVillageOne");
		this.GetComponent<BoxCollider>().enabled = false;
	}

    /*void OnMouseOver(){
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
    	Destroy(FakeAxe);
    	Destroy(gameObject);
    }
    void SetDisplayActive(bool b){
    	ActionDisplay.SetActive(b);
    	ActionText.SetActive(b);
    	ExtraCursor.SetActive(b);
    }*/
}
