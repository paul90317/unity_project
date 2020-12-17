using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gate : MonoBehaviour {

    public GameObject close;
    GameObject cl;
    bool f, f2, f3;
    Animator an;
    // Use this for initialization
    void Awake () {
        f = true;
        f2 = true;
        f3 = false;
    }
    
    // Update is called once per frame
    void Update () {
        if (f && transform.parent && transform.parent.tag == "start") 
        {
            cl = Instantiate<GameObject>(close, transform);
            an = cl.GetComponent<Animator>();
            cl.transform.localPosition = new Vector3(0, 0, -1);
            f = false;
        }
        if (f2 && transform.parent && transform.parent.tag == "finish") 
        {
            if (an)
            {
                an.SetTrigger("open");
            }
            f3 = true;
            f2 = false;
        }
        if (f3 && cl && cl.transform.GetChild(0).localPosition.y < 0.0001f)
        {
            Destroy(cl);
            f3 = false;
        }
    }
}
