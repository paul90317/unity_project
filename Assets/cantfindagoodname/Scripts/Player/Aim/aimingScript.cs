using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimingScript : MonoBehaviour {

    [SerializeField]
    public GameObject radar;
    private bool autoAim;
    private void Update()
    {
        aim();
    }
    private void aim()
    {
        if (Input.GetMouseButtonUp(1) || radar.GetComponent<Radar>().enemyInRange == false)
            autoAim = false;
        else if(Input.GetMouseButton(1))
            autoAim = true;

        if (autoAim)
            aimTowards(radar.GetComponent<Radar>().enemyPos);
        else
            aimTowards(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
    private void aimTowards(Vector2 targetPos)
    {
        if ((targetPos - (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position).x < 0)
        {
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(2).GetComponent<SpriteRenderer>().flipX=true;
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).GetComponent<SpriteRenderer>().flipX=true;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(2).GetComponent<SpriteRenderer>().flipX=false;
            GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).GetComponent<SpriteRenderer>().flipX=false;
        }

       Vector2 dir = targetPos - (Vector2)transform.position;
        Vector2 refdir = (Vector2)(transform.GetChild(0).transform.right);

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 180f;
        float refangle = Mathf.Atan2(refdir.y, refdir.x) * Mathf.Rad2Deg + 180f;

        transform.GetChild(0).transform.RotateAround(transform.position, Vector3.forward, angle-refangle);
    }
}
