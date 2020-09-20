using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRotate : MonoBehaviour
{
    public int RotateSpeed;
    public AudioSource CollectSound;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,RotateSpeed,0,Space.World);
    }
    /*void OnTriggerEnter(Collider other){
    	CollectSound.Play();
    	this.gameObject.SetActive(false);
    }*/
}
