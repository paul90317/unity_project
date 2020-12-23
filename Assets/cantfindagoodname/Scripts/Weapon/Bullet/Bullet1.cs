using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet1 : MonoBehaviour {

    private Rigidbody2D rb;
    private float bulletForce = 30f;
    private Vector2 shootingDirection;

    [SerializeField]
    public int damage;

	void Start () {
        damage = 1;

        rb = GetComponent<Rigidbody2D>();
        shootingDirection = (GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).transform.right).normalized;
	}
	
	void Update () {
        rb.AddForce(shootingDirection * bulletForce, ForceMode2D.Impulse);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            Destroy(gameObject);
        else if (collision.gameObject.CompareTag("monster"))
        {
            collision.GetComponent<monsterHealth>().hurt(damage);
            Destroy(gameObject);
        }
    }
}
