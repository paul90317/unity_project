using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int health;
    public int shield;
    public int startRecoverTime;
    public int recoverTime;
    int cnt_s;
    int cnt_r;
    int h;
    int s;

    private void Start()
    {
        h = health;
        s = shield;
        cnt_s = 0;
        cnt_r = 0;
    }

    public void hurt(int damage)
    {
        int t = s - damage;
        if (t < 0)
        {
            h += t;
            s = 0;
        }
        else
        {
            s = t;
        }
        cnt_s = 0;
        cnt_r = 0;
    }

    private void Update()
    {
        if (h <= 0)
        {
            Debug.Log("You Lose!");
        }
        if (cnt_r >= recoverTime && s < shield)
        {
            cnt_r = 0;
            s++;
        }
    }
    private void FixedUpdate()
    {
        if (cnt_s < startRecoverTime) cnt_s++;
        if (cnt_s >= startRecoverTime && s < shield) cnt_r++;
    }
}
