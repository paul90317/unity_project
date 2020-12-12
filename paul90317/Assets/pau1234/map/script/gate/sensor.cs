using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensor : MonoBehaviour {

    GameObject room;
	// Use this for initialization
	void Start () {
        room = transform.parent.gameObject;
	}
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            room.tag = "start";
        }
    }
    
    // Update is called once per frame
    void Update () {
        if (room.tag == "start"||room.tag=="finish")
        {
            Destroy(transform.gameObject);
        }
	}
}
