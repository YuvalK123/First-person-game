using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC002Dest : MonoBehaviour
{
    public int pivotPoint;
    float[,] positions;


    void Start(){
    	float y = 101.134f;
    	positions = new float[,]{
		    	{419.03f,y,189.39f},
		    	{416.65f,y,161.6f},
		    	{425.3f,y,173.3f},
		    	{444.04f,y,191.14f},
		    	{435.47f,y,197f}
    };

    }

    (float a, float b, float c) GetCoordinates(int index){
    	int i = 0;
    	float x = positions[pivotPoint, i++];
    	float y = positions[pivotPoint, i++];
    	float z = positions[pivotPoint, i++];
    	return (x,y,z);
    }

    void OnTriggerEnter(Collider other){
    	if(other.tag == "NPC"){
    		(float x, float y, float z) = GetCoordinates(pivotPoint);
    		Vector3 point = new Vector3(x,y,z);
    		this.gameObject.transform.position = point;
    		pivotPoint = (pivotPoint + 1)%5;
    	}
    }
}
