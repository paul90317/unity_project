using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRow : MonoBehaviour {

    public int max_len;
    public Weapon init;
    public GameObject drop;
    Weapon[] weapons;
    int now;
    int len;
    private void Awake()
    {
        len = 1;
        weapons = new Weapon[max_len];
        weapons[0] = init;
        takeout(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            takeout((now + 1) % len);
        }
        
        if (Input.GetMouseButton(0))
        {
            weapons[now].fire(transform.position, transform.right);
        }
    }
    private void FixedUpdate()
    {
        for(int i = 0; i < len; i++)
        {
            weapons[i].cool();
        }
    }
    void takeout(int i)
    {
        now = i;
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = weapons[i].picture;
        transform.GetChild(0).GetComponent<SpriteRenderer>().size = weapons[i].size;
        transform.GetChild(0).localPosition = new Vector3(weapons[i].handDistance, 0, 0);

    }

    public void pickup(Weapon wea0)
    {
        if (len < max_len)
        {
            weapons[len++] = wea0;
            takeout(len - 1);
        }
        else
        {
            GameObject d = Instantiate<GameObject>(drop);
            d.transform.position = transform.position;
            d.SendMessage("drop", weapons[now]);
            weapons[now] = wea0;
            takeout(now);
        }
    }
}
