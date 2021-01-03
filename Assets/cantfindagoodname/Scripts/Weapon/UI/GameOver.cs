using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public static bool gameOver = false;

    [SerializeField]
    public Scene menuScene;
    private GameObject EndGameUI;

    private void Awake()
    {
        EndGameUI = GameObject.FindObjectOfType<GameOverPanel>().gameObject;
    }
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHP>().hp <= 0)
        {
            if (gameOver == false)
            {
                // if need animation
                // Invoke("EndGame", 1f);
                gameOver = true;
                EndGame();
            }
        }
    }
    public void EndGame()
    {
        gameObject.GetComponent<GameOverAudio>().triggerGameOverSFX();

        EndGameUI.SetActive(true);
        Time.timeScale = 0f;
        gameOver = true;
    }
    public void backToMainMenu()
    {
        gameObject.GetComponent<GameOverAudio>().endEvent();

        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
