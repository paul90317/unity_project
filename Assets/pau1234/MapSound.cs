using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSound : MonoBehaviour {

    public AudioClip start;
    public AudioClip boss;
    AudioSource asd;
    bool playing;
	// Use this for initialization
	void Awake () {
        asd = GetComponent<AudioSource>();
        playing = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!asd.isPlaying && playing)
        {
            asd.Play();
        }
	}
    public void bossSound()
    {
        asd.clip = boss;
        asd.Play();
    }
    public void startSound()
    {
        asd.clip = start;
        asd.Play();
    }
    public void stopSound()
    {
        playing = false;
        asd.Stop();
    }
}
