using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AxeSwing : MonoBehaviour
{
	public GameObject theAxe;
	public static bool isSwinging = false;
	public AudioSource swingSound;
    public static bool holdingAxe = false;
	private string fire = "Fire1"; 
	private string animationName = "SwingAxe";

    // damage
    public GameObject damageObject;
    public int damageAmount = 5;
    public float allowedRange = 3.1f;
     // Update is called once per frame
    void Update()
    {
        if(!holdingAxe){
            return;
        }
        if (Input.GetButtonDown(fire) && !isSwinging){
            if (isSwinging){
                //Damage();
            }
            //if(!isSwinging){
            	isSwinging = true;
                Damage();
            	StartCoroutine(SwingTheAxe());
            //}
        }
    }

    void Damage(){
        RaycastHit hit;
        if (Physics.Raycast(damageObject.transform.position, damageObject.transform.TransformDirection(Vector3.forward),out hit)){
            float targettDistance = hit.distance;
            if (targettDistance <= allowedRange){
                hit.transform.SendMessage("DeductPoints",damageAmount, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    IEnumerator SwingTheAxe(){
    	swingSound.Play();
    	theAxe.GetComponent<Animation>().Play(animationName);
    	yield return new WaitForSeconds(0.55f);
    	isSwinging = false;

    }
}
