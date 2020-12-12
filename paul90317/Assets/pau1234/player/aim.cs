using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim : MonoBehaviour {

    CircleCollider2D search;
    public float range;
    bool obj;

    private void Awake()
    {
        search = GetComponent<CircleCollider2D>();
        search.radius = 0f;
        obj = false;
    }
    // Update is called once per frame
    void Update () {
        if (search.radius >= range)
        {
            search.radius = 0f;
            obj = false;
        }
        else
        {
            if (search.radius < 0.5f)
            {
                search.radius += 0.1f;
            }
            else
            {
                search.radius += 0.9f;
            }
        }
        if (!obj)
        {
            transform.right = Input.mousePosition - new Vector3((float)Screen.width / 2, (float)Screen.height / 2, 0);
        }
        transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = (transform.right.x < 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "monster")
        {
            Vector3 dir = collision.transform.position - transform.position;
            dir.z = 0;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, range);
            if (hit&&hit.collider.gameObject.tag == "monster")
            {
                obj = true;
                search.radius = 0f;
                transform.right = dir;
            }
        }
    }
}
