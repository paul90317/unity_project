using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour {

    private float moveSpeed = 10f;
    private Rigidbody2D rb;

    private Vector2 movement;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update () {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
	}

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
