using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCChat : MonoBehaviour
{
// going to be the actual distance from player casting script;
	public float TheDistance;
    public static bool skeletonSlayed = false;
	public GameObject villageExitTrigger;
    // the two text objects
	public GameObject ActionDisplay;
	public GameObject ActionText;
	public GameObject ExtraCursor;
	public GameObject subBox;
	public GameObject subText;

	public GameObject mainBlocker;
	public GameObject blockText;

    // Update is called once per frame
    void Update()
    {
        TheDistance = LayerCasting.DistanceFromTarget;

    }

    void OnMouseOver(){
    	if (TheDistance <= 4){
    		ActionText.GetComponent<Text>().text = "Talk";

    		SetDisplayActive(true);
    		if (Input.GetButtonDown("Action")){
    			Talk();
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

    string getSubText(){
        string txt = "Please come back to me when you have a weapon";
        if(skeletonSlayed){
            txt = "Thank you for your help! Here is the key of the village.";
            villageExitTrigger.SetActive(true);
        }
    	else if (DialougeState.stateAxeTake){
    		txt = "I see you have a weapon. I have a small favour to ask of you. Please can you elliminate the skeleton threat just outside the village!";
    	}
    	return txt;
    }

    void Talk(){
    	subBox.SetActive(true);
    	subText.GetComponent<Text>().text = getSubText();
    	this.GetComponent<BoxCollider>().enabled = false;
    	SetDisplayActive(false);
    	if (DialougeState.stateAxeTake){
    		mainBlocker.SetActive(false);
    		blockText.SetActive(false);
    	}
    	StartCoroutine(ResetChat());
    }

    IEnumerator ResetChat(){
    	yield return new WaitForSeconds(3f);
    	subText.GetComponent<Text>().text = "";
    	subBox.SetActive(false);
        if(!skeletonSlayed){
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }

    void SetDisplayActive(bool b){
    	ActionDisplay.SetActive(b);
    	ActionText.SetActive(b);
    	ExtraCursor.SetActive(b);
    }
}
