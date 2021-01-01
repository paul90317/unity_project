using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster_bullet : MonoBehaviour {

    public float speed;
    public int damage;
    void Awake()
    {
    }
    // Use this for initialization
    void FixedUpdate () {
        
        GetComponent<Rigidbody2D>().velocity = (-1) * transform.right * speed;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" || collision.transform.tag == "box")
        {
            collision.gameObject.SendMessage("hurt", damage);
            Destroy(gameObject);
        }
        if(collision.transform.tag != "monster" && !transform.GetComponent<Collider2D>().isTrigger)
            Destroy(gameObject);
    }
}
