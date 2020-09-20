using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonWonderer : MonoBehaviour
{
	public int xPos;
	public int zPos;

	void OnTriggerEnter(Collider other){
		if(other.tag == "Enemy"){
			BoxCollider box = this.gameObject.GetComponent<BoxCollider>();
			box.enabled = false;
			xPos = Random.Range(447,472);
			zPos = Random.Range(206,234);
			float y = this.gameObject.transform.position.y;
			this.gameObject.transform.position = new Vector3(xPos,y, zPos);
			box.enabled = true;

		}
	}
}
