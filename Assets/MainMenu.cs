using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string gameplayLevelName;
    public Button newGameButton;
    public Button quitButton;

    void NewGameButtonHandler()
    {
        SceneManager.LoadScene(gameplayLevelName);
    }

    void QuitButtonHandler()
    {
        Application.Quit();
    }

	// Use this for initialization
	void Start () {
        newGameButton.onClick.AddListener(NewGameButtonHandler);
        quitButton.onClick.AddListener(QuitButtonHandler);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
