using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_move : MonoBehaviour {

    public float moveSpeed;
    public GameObject monster_bullet;
    private float xmovement,ymovement;
    private float tmp,time,bullet_time;
    private System.Random r;
    private Rigidbody2D rb;
	private void Awake () {
        r = new System.Random();
        time = 2.0f;
	}
    // Update is called once per frame
    void Update()
    {
        transform.localPosition += new Vector3(xmovement * moveSpeed, ymovement * moveSpeed, 0);
    }
    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        if (transform.parent.tag == "start" && time >= 4.0f)
        {
            tmp = r.Next(0, 361);
            time = 0;
            ymovement = Mathf.Sin(tmp / 57.29f);
            xmovement = Mathf.Cos(tmp / 57.29f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag != "Player" && collision.transform.tag != "bullet")
        {
            xmovement *= -1;
            ymovement *= -1;
        }
    }
}
