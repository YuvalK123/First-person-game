using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplahToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScreenChange());
    }


    IEnumerator ScreenChange(){
    	yield return new WaitForSeconds(7.5f);
    	SceneManager.LoadScene(1);
    }
}
