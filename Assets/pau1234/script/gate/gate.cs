using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour {

    public GameObject close;
    GameObject cl;
    bool f;
	// Use this for initialization
	void Awake () {
        f = true;
    }
    
    // Update is called once per frame
    void Update () {
        if (f&&  transform.parent&&transform.parent.tag == "start")
        {
            cl = Instantiate<GameObject>(close, transform);
            cl.transform.localPosition = new Vector3(0, 0, -1);
            f = false;
        }
        if (transform.parent && transform.parent.tag == "finish")
        {
            Destroy(cl);
        }
    }
}
