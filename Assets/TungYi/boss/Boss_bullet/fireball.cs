using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {

    public GameObject small_fireball;
    public float speed;
    public int damage;
    private float timer;
    private Vector3 movement;
    private float tempx, tempy;
    void Awake()
    {
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("FFFFFFFFFFFF");
        }
    }
    // Use this for initialization
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        GetComponent<Rigidbody2D>().velocity = (-1) * transform.right * speed;
        if (timer >= 2.0f)
        {
            movement = transform.right;
            GameObject b = Instantiate<GameObject>(small_fireball);
            b.SetActive(true);
            b.transform.right = movement * 1.5f * speed;
            b.transform.position = transform.position;
            b.GetComponent<monster_bullet>().speed *= 1.5f;
            tempx = (-1) * movement.x;
            tempy = (-1) * movement.y;
            movement.x = tempx * Mathf.Cos(-30.0f/57.29f) - tempy * Mathf.Sin(-30.0f / 57.29f);
            movement.y = tempy * Mathf.Cos(-30.0f / 57.29f) + tempx * Mathf.Sin(-30.0f / 57.29f);
            b = Instantiate<GameObject>(small_fireball);
            b.SetActive(true);
            b.transform.right = (-1) * movement * 1.5f * speed;
            b.transform.position = transform.position;
            b.GetComponent<monster_bullet>().speed *= 1.5f;
            movement.x = tempx * Mathf.Cos(30.0f / 57.29f) - tempy * Mathf.Sin(30.0f / 57.29f);
            movement.y = tempy * Mathf.Cos(30.0f / 57.29f) + tempx * Mathf.Sin(30.0f / 57.29f);
            b = Instantiate<GameObject>(small_fireball);
            b.SetActive(true);
            b.transform.right = (-1) * movement * 1.5f * speed;
            b.transform.position = transform.position;
            b.GetComponent<monster_bullet>().speed *= 1.5f;
            movement.x = tempx * Mathf.Cos(-15.0f / 57.29f) - tempy * Mathf.Sin(-15.0f / 57.29f);
            movement.y = tempy * Mathf.Cos(-15.0f / 57.29f) + tempx * Mathf.Sin(-15.0f / 57.29f);
            b = Instantiate<GameObject>(small_fireball);
            b.SetActive(true);
            b.transform.right = (-1) * movement * 1.5f * speed;
            b.transform.position = transform.position;
            b.GetComponent<monster_bullet>().speed *= 1.5f;
            movement.x = tempx * Mathf.Cos(15.0f / 57.29f) - tempy * Mathf.Sin(15.0f / 57.29f);
            movement.y = tempy * Mathf.Cos(15.0f / 57.29f) + tempx * Mathf.Sin(15.0f / 57.29f);
            b = Instantiate<GameObject>(small_fireball);
            b.SetActive(true);
            b.transform.right = (-1) * movement * 1.5f * speed;
            b.transform.position = transform.position;
            b.GetComponent<monster_bullet>().speed *= 1.5f;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" || collision.transform.tag == "box")
        {
            collision.gameObject.SendMessage("hurt", damage);
            Destroy(gameObject);
        }
        if (collision.transform.tag != "monster" && !transform.GetComponent<Collider2D>().isTrigger)
            Destroy(gameObject);
    }
}
