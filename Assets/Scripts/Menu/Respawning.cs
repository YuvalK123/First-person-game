using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    	HealthMonitor.healthPoints = 300;
        SceneManager.LoadScene(1);
    }

}
