using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAudio : MonoBehaviour {
    public AudioClip failBackground, failTriggerSound;
    private GameObject mapManager;
    private AudioClip previousClip;

    private AudioSource audioSource;

    private float wait;
    private bool check;
    public void triggerGameOverSFX()
    {
        audioSource.enabled = true;

        mapManager = GameObject.FindGameObjectWithTag("MapManager");
        mapManager.SetActive(false);

        playAudio();
    }
    private void playAudio()
    {
        audioSource.clip = failTriggerSound;
        audioSource.Play();
    }
    private void switchToBackground()
    {
        audioSource.clip = failBackground;
        audioSource.Play();
        audioSource.loop = true;
    }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = false;
    }
    private void Update()
    {
        if (audioSource.enabled && !GetComponent<AudioSource>().isPlaying) 
        {
            switchToBackground();
            GetComponent<AudioSource>().Play();
        }
    }
    public void endEvent()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().loop = false;

        audioSource.enabled = false;

        mapManager.SetActive(true);
    }
}
