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
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -10f;

        if (Input.GetMouseButtonUp(1) || radar.GetComponent<Radar>().enemyInRange == false)
            autoAim = false;
        else if(Input.GetMouseButton(1))
            autoAim = true;

        if (autoAim)
            aimTowards(Camera.main.WorldToScreenPoint(radar.GetComponent<Radar>().enemyPos));
        else
            aimTowards(mousePos);
    }
    private void aimTowards(Vector3 targetPos)
    {
        Vector3 rotatingAxisPos = Camera.main.WorldToScreenPoint(GameObject.FindGameObjectWithTag("RotatingAxis").transform.position);
        targetPos.x = targetPos.x - rotatingAxisPos.x;
        targetPos.y = targetPos.y - rotatingAxisPos.y;

        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg+180f;
        GameObject.FindGameObjectWithTag("RotatingAxis").transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
