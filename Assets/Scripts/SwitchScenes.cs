using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SwitchScenes : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void GoToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

	public void GoToTutorial()
	{
		SceneManager.LoadScene("Tutorial");
	}

}
