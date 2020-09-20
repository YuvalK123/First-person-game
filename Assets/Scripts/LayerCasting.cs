using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerCasting : MonoBehaviour
{
    public static float DistanceFromTarget;
    public float ToTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;
        var forward = Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out Hit);
        if (forward){
            ToTarget = Hit.distance;
            DistanceFromTarget = ToTarget;
        }
    }
}
