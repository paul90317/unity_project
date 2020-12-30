using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class DetectPlayer : MonoBehaviour {
    public Vector2 playerPos;

    private void Awake()
    {
        playerPos = transform.position;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 vectorToPlayer = collision.transform.position - transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, vectorToPlayer, 30f, LayerMask.GetMask("Wall") | LayerMask.GetMask("Player"));
            if (hit && hit.collider.gameObject.CompareTag("Player"))
            {
                playerPos = collision.transform.position;
            }
        }
    }
}
