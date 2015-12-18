using UnityEngine;
using System.Collections;

public class FishManScript : MonoBehaviour {

    // audio variables
    private AudioSource[] audioSources;
    private AudioSource spawnSound;
    private AudioSource hitSound;
    private AudioSource deathSound;

	// Use this for initialization
	void Start()
    {
        audioSources = GetComponents<AudioSource>();

        spawnSound = audioSources[0];
        hitSound = audioSources[1];
        deathSound = audioSources[2];
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
