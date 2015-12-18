using UnityEngine;
using System.Collections;

public class AboutMenuScript : MonoBehaviour {

    public GameObject previousMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GoBack()
    {
        // hide this menu and show the previous menu
        gameObject.SetActive(false);
        previousMenu.SetActive(true);
    }
}
