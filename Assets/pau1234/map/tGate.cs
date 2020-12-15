using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class tGate : MonoBehaviour {
    GameObject[] transitions;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.G))
        {
            transitions = GameObject.FindGameObjectsWithTag("transition");
            for (int i = 0; i < transitions.Length; i++)
            {
                transitions[i].GetComponent<Animator>().SetTrigger("start");
            }
            GameObject.FindWithTag("MapManager").SendMessage("NextScene");
        }
    }
}
