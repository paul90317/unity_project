using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walker : MonoBehaviour {
    public GameObject unit;
    // Use this for initialization
    bool flag;
    private void Awake()
    {
        flag = false;
    }
    public bool isVertical()
    {
        return flag;
    }
    public void vertical()
    {
        flag = true;
        transform.Rotate(0, 0, 90);
    }
    public void shot()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 1000);
        int right = myMethod.round(hit.distance);
        if (flag) hit.collider.transform.parent.gameObject.SendMessage("gateD");
        else hit.collider.transform.parent.gameObject.SendMessage("gateL");
        hit = Physics2D.Raycast(transform.position, -transform.right, 1000);
        int left = myMethod.round(hit.distance);
        if (flag) hit.collider.transform.parent.gameObject.SendMessage("gateU");
        else hit.collider.transform.parent.gameObject.SendMessage("gateR");
        for (int i = -1; i >= -left; i--)
        {
            GameObject t = Instantiate<GameObject>(unit, transform);
            t.transform.localPosition = new Vector3(i, 0, 0);
        }
        for (int i = 0; i < right + 1; i++)
        {
            GameObject t = Instantiate<GameObject>(unit, transform);
            t.transform.localPosition = new Vector3(i, 0, 0);
        }
    }
}
