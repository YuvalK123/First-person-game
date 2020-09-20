using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthMonitor : MonoBehaviour
{
	public static int healthPoints = 300;
	public int internalHealth;
	public GameObject healthDisplay;
	public GameObject healthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        internalHealth = healthPoints;
        healthDisplay.GetComponent<Text>().text = "HP: " + healthPoints;
        healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(healthPoints, 30);
        if (healthPoints <= 0){
        	SceneManager.LoadScene(2);
        }
    }
}
