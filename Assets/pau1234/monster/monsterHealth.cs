using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterHealth : MonoBehaviour {

    public int health;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public void hurt(int damage)
    {
        if (!transform.parent || transform.parent.tag == "start")
        {
            health -= damage;
        }
    }

    private void Update()
    {
        if (transform.parent && transform.parent.tag == "start")
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        if (health <= 0)
        {
            if (transform.parent)
            {
                transform.parent.gameObject.SendMessage("removeMonster");
            }
            Destroy(gameObject);
        }
    }
}
