using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tGate : MonoBehaviour {
    public int next;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.G))
        {
            GameObject.DontDestroyOnLoad(GameObject.FindWithTag("Player"));
            SceneManager.LoadScene(next);
        }
    }
}
