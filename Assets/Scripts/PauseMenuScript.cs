using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

    public GameObject aboutMenu;
    public GameObject helpMenu;

	// Use this for initialization
	void Start () {
        // pause the game
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ResumeGame()
    {
        // hide this menu and unpause the game
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        // reload the current level
        Application.LoadLevel(Application.loadedLevel);
    }

    public void About()
    {
        // hide this menu and show the help menu
        gameObject.SetActive(false);
        aboutMenu.SetActive(true);
    }

    public void Help()
    {
        // hide this menu and show the help menu
        gameObject.SetActive(false);
        helpMenu.SetActive(true);
    }

    public void QuitGame()
    {
        // quit the game
        Application.Quit();
    }
}
