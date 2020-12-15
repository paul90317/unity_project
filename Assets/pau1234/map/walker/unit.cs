using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour {
    public GameObject floor;
    public GameObject wall;
    // Use this for initialization
    bool flag;
	void Awake() {
        flag = transform.parent.gameObject.GetComponent<walker>().isVertical();
        GameObject[] t = new GameObject[3];
        t[0] = Instantiate<GameObject>(wall, transform);
        t[0].transform.localPosition = new Vector3(0, 2, 0);
        t[1] = Instantiate<GameObject>(floor, transform);
        t[1].transform.localPosition = new Vector3(0, 0, 0);
        t[1].GetComponent<SpriteRenderer>().size = new Vector2(1, 3);
        t[2] = Instantiate<GameObject>(wall, transform);
        t[2].transform.localPosition = new Vector3(0, -2, 0);
        if (flag)
        {
            t[0].transform.Rotate(0, 0, -90);
            t[2].transform.Rotate(0, 0, -90);
        }
    }
}
