using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	// Use this for initialization
	void Start () {
        L = R = U = D = false;
        speed = 450f;
	}
    bool L;
    bool R;
    bool U;
    bool D;
    float speed;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)) L = true;
        if (Input.GetKeyDown(KeyCode.D)) R = true;
        if (Input.GetKeyDown(KeyCode.W)) U = true;
        if (Input.GetKeyDown(KeyCode.S)) D = true;

        if (Input.GetKeyUp(KeyCode.A)) L = false;
        if (Input.GetKeyUp(KeyCode.D)) R = false;
        if (Input.GetKeyUp(KeyCode.W)) U = false;
        if (Input.GetKeyUp(KeyCode.S)) D = false;
        Vector3 v = new Vector3(0,0,0);
        if (L) v += (-transform.right * Time.deltaTime * speed);
        if (R) v += (transform.right * Time.deltaTime * speed);
        if (D) v += (-transform.up * Time.deltaTime * speed);
        if (U) v += (transform.up * Time.deltaTime * speed);
        GetComponent<Rigidbody2D>().velocity = v;
    }
}
