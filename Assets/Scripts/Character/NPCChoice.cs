using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;
public class NPCChoice : MonoBehaviour
{
	public GameObject ThePlayer;
    // the two text objects
	public GameObject ActionDisplay;
	public GameObject ActionText;
	public GameObject ExtraCursor;
	public GameObject subBox;
	public GameObject subText;
	public float desiredDistance = 4f;
	private int chatStage = 0; 

    public GameObject YesButton;
    public GameObject NoButton;

    public bool takenQuest = false;
    public static bool questComplete = false;
    public GameObject woodPile;
    public GameObject gold;

    void SetDisplayActive(bool b){
        ActionDisplay.SetActive(b);
        ActionText.SetActive(b);
        ExtraCursor.SetActive(b);
    }
    void Update(){
        //Cursor.visible = true;
    }
    void LookAtPlayer(){
    	//point based on player, and y on npc
    	Vector3 point = new Vector3(ThePlayer.transform.position.x,this.transform.position.y,ThePlayer.transform.position.z);
    	this.transform.LookAt(point);
    }
    void OnMouseOver(){
        if(takenQuest && !questComplete){
            return;
        }
    	float TheDistance = LayerCasting.DistanceFromTarget;
    	if (TheDistance <= desiredDistance){
    		ActionText.GetComponent<Text>().text = "Talk";
    		SetDisplayActive(true);
    		if (Input.GetButtonDown("Action")){
    			ThePlayer.GetComponent<FirstPersonController>().enabled = false;
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
    	string txt = "";
    	if(!questComplete){
			txt = "Hello there, My name is Fashioniqua and i patrol the village.";
    	}else{
            txt = "Thank you for this. Here is your reward.";
        }

    	return txt;
    }

    void Idle(){
    	this.GetComponent<Animator>().Play("Idle");
    	this.GetComponent<NavMeshAgent>().enabled = false;
    	this.GetComponent<NPCAINav>().enabled = false;
    }

    void Walk(){
    	this.GetComponent<Animator>().Play("Walk");
    	this.GetComponent<NavMeshAgent>().enabled = true;
    	this.GetComponent<NPCAINav>().enabled = true;
    }

    void Talk(){
    	LookAtPlayer();
    	Idle();
        takenQuest = true;
    	subBox.SetActive(true);
    	subText.GetComponent<Text>().text = getSubText();
    	this.GetComponent<BoxCollider>().enabled = false;
    	SetDisplayActive(false);
        if(!questComplete){
            StartCoroutine(StartSelectConvo());
        }
        else{
            StartCoroutine(QuestComplete());
        }
    	
    }



    IEnumerator StartSelectConvo(){
    	yield return new WaitForSeconds(2.5f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    	subText.GetComponent<Text>().text = "Can you go to the next village and collect some wood?";
    	YesButton.SetActive(true);
        NoButton.SetActive(true);
    }

    IEnumerator StartYes(){
    
        subText.GetComponent<Text>().text = "Thank you. i'll see you when ou return.";
        yield return new WaitForSeconds(3.5f);
        woodPile.SetActive(true);
        EndOptions();
    }

    IEnumerator QuestComplete(){
        questComplete = false;
        takenQuest = false;
        yield return new WaitForSeconds(3);
        gold.GetComponent<Text>().text = "Gold: 100";
        EndOptions();
    }

    public void YesOption(){
        YesButton.SetActive(false);
        NoButton.SetActive(false);
        StartCoroutine(StartYes());
    }
    public void NoOption(){
        EndOptions();
    }

    void EndOptions(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        subText.GetComponent<Text>().text = "";
        subBox.SetActive(false);
        YesButton.SetActive(false);
        NoButton.SetActive(false);
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;


        this.GetComponent<BoxCollider>().enabled = true;
        
        Walk();
    }
}
