using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectGem : MonoBehaviour
{
	// going to be the actual distance from player casting script;
	public float TheDistance;
	// the two text objects
	public GameObject ActionDisplay;
	public GameObject ActionText;
	public GameObject ExtraCursor;
	// the Gem itself, for the start
	public AudioSource CollectSound;

    // Update is called once per frame
    void Update()
    {
        TheDistance = LayerCasting.DistanceFromTarget;

    }

    void OnMouseOver(){
    	if (TheDistance <= 4){
            ActionText.GetComponent<Text>().text = "Take Gem";
    		SetDisplayActive(true);
    		if (Input.GetButtonDown("Action")){
    			CollectSound.Play();
    			this.gameObject.SetActive(false);
                SetDisplayActive(false);
    		}
    	}
    	else{
    		SetDisplayActive(false);
    	}
    }

    void OnMouseExit(){
    	SetDisplayActive(false);
    }

    void SetDisplayActive(bool b){
    	ActionDisplay.SetActive(b);
    	ActionText.SetActive(b);
    	ExtraCursor.SetActive(b);
    }
}
