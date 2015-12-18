using UnityEngine;
using System.Collections;

public class WizardScript : MonoBehaviour {

    // audio variables
    private AudioSource[] audioSources;
    //private AudioSource spawnSound;
    private AudioSource hitSound;
    private AudioSource deathSound;

	// Use this for initialization
	void Start()
    {
        audioSources = GetComponents<AudioSource>();

        hitSound = audioSources[0];
        deathSound = audioSources[1];
	}
	
	// Update is called once per frame
	void Update()
    {
	
	}

    void playSound(AudioSource sound)
    {
        sound.Play();
    }
}
