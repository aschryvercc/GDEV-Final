using UnityEngine;
using System.Collections;

public class GameOverMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start()
    {
        // pause the game
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update()
    {
	
	}

    public void RetryLevel()
    {
        // load the current level again and hide this menu
        Application.LoadLevel(Application.loadedLevel);
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        // quit game
        Application.Quit();
    }
}
