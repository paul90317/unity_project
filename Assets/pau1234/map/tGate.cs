﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class tGate : MonoBehaviour {
    GameObject transition;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.G))
        {
            GameObject.FindWithTag("transition").GetComponent<Animator>().SetInteger("next", 1);
            GameObject.FindWithTag("MapManager").SendMessage("NextScene");
        }
    }
}