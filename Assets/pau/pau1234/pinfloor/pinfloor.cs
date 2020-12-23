using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinfloor : MonoBehaviour {

    public int coolDown;
    int cnt;
	
    void Awake()
    {
        cnt = 0;
        Debug.Log("awake");
    }

    private void OnEnable()
    {
        cnt = coolDown;
    }
    private void OnDisable()
    {
        cnt = 0;
    }
    private void FixedUpdate()
    {
        cnt++;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (cnt >= coolDown && collision.tag == "Player")
        {
            cnt = 0;
            Debug.Log("hurt");
        }
    }
}
