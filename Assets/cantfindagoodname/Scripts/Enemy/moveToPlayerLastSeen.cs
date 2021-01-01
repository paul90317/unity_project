using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToPlayerLastSeen : MonoBehaviour {
    public GameObject detectRange;

    private float moveSpeed = 5f;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        moveDirection = detectRange.GetComponent<DetectPlayer>().playerPos - (Vector2)transform.position;
        rb.MovePosition(rb.position + moveSpeed * moveDirection.normalized * Time.fixedDeltaTime);
    }
}
