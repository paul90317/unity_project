using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_attack : MonoBehaviour
{
    public GameObject monster_bullet;
    private Rigidbody2D rb;
    private float time;
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
        time += Time.fixedDeltaTime;
        if (transform.parent.tag == "start" && time >= 0.6f)
        {
            time = 0;
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
    }
}
