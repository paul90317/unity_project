﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasure : MonoBehaviour {

    // Use this for initialization
    public GameObject[] item;
    System.Random r;
    bool opened;
    private void Awake()
    {
        opened = false;
        r = new System.Random();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!opened && collision.gameObject.tag == "Player") 
        {
            GetComponent<Animator>().SetTrigger("open");
            opened = true;
            GameObject g = Instantiate<GameObject>(item[r.Next(item.Length)]);
            g.transform.position = transform.position + new Vector3(0, 0.25f, 0);
        }
    }
}