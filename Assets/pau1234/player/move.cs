using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D rb;

    private Vector2 movement;
    private void Awake()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        bool f0 = transform.GetChild(1).right.x < 0;
        GetComponent<SpriteRenderer>().flipX = f0;
        transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = f0;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
