using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

    public GameObject aboutMenu;
    public GameObject helpMenu;

	// Use this for initialization
	void Start()
    {
        // pause the game time and wait for the user to select an option from the menu
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update()
    {
	
	}

    public void StartGame()
    {
        // hide the menu and start the game time
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void About()
    {
        // hide this menu and show the about menu
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
