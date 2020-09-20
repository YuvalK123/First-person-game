using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
    public void NewGameButton(){
    	SceneManager.LoadScene(3);
    }

    public void LoadGameButton(){
    	//SceneManager.LoadScene(#);
    }

    public void CreditsButton(){
    	//SceneManager.LoadScene(#);
    }

    public void OptionsButton(){
    	//UI for options to be built
    }

    public void QuitButton(){
    	Application.Quit();
    }
}
