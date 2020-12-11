using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class died : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            transform.parent.gameObject.SendMessage("removeMonster");
            Destroy(gameObject);
        }
    }
}
