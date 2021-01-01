using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_attack : MonoBehaviour {

    public GameObject monster_bullet;
    public GameObject fireball;
    private Rigidbody2D rb;
    private float timer1,timer2,timer3;
    private float xgap, ygap;
    private Vector3 movement;

    // Use this for initialization
    void Awake()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        timer1 += Time.fixedDeltaTime;
        timer2 += Time.fixedDeltaTime;
        timer3 += Time.fixedDeltaTime;
        if (/*transform.parent.tag == "start" &&*/ timer1 >= 0.6f) //normal attack
        {
            timer1 = 0;
            xgap = transform.position.x - rb.transform.position.x;
            ygap = transform.position.y - rb.transform.position.y;
            movement.x = xgap / Mathf.Sqrt(xgap * xgap + ygap * ygap);
            movement.y = ygap / Mathf.Sqrt(xgap * xgap + ygap * ygap);
            movement.z = 0;
            GameObject b = Instantiate<GameObject>(monster_bullet);
            b.SetActive(true);
            b.transform.right = movement;
            b.transform.position = transform.position;
        }
        if (/*transform.parent.tag == "start" &&*/ timer2 >= 3.2f) //skill fireball
        {
            timer2 = 0;
            xgap = transform.position.x - rb.transform.position.x;
            ygap = transform.position.y - rb.transform.position.y;
            movement.x = xgap / Mathf.Sqrt(xgap * xgap + ygap * ygap);
            movement.y = ygap / Mathf.Sqrt(xgap * xgap + ygap * ygap);
            movement.z = 0;
            GameObject b = Instantiate<GameObject>(fireball);
            b.SetActive(true);
            b.transform.right = movement;
            b.transform.position = transform.position;
        }
        if (/*transform.parent.tag == "start" &&*/ timer3 >= 10.0f)
        {
            timer3 = 0;
            for(int i = 1; i < 37; i++)
            {
                movement.x = Mathf.Cos(10f * i / 57.29f);
                movement.y = Mathf.Sin(10f * i / 57.29f);
                movement.z = 0;
                GameObject b = Instantiate<GameObject>(monster_bullet);
                b.SetActive(true);
                b.transform.right = movement/2;
                b.transform.position = transform.position;
            }
        }
    }
}
