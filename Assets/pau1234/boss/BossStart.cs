using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStart : MonoBehaviour {
    
    Animator animator;
    UnityEngine.UI.Text bossName;
    UnityEngine.UI.Image bossPic;
    MapSound ms;
    GameObject room;
    bool f;
	// Use this for initialization
	void Start () {
        GameObject transition = GameObject.FindWithTag("transition");
        animator = transition.GetComponent<Animator>();
        bossName = transition.transform.GetChild(4).GetComponent<UnityEngine.UI.Text>();
        bossPic = transition.transform.GetChild(5).GetComponent<UnityEngine.UI.Image>();
        bossName.text = name.Split(new char[1] { '(' })[0];
        bossPic.sprite = GetComponent<SpriteRenderer>().sprite;
        ms = GameObject.FindWithTag("MapManager").GetComponent<MapSound>();
        room = transform.parent.gameObject;
        f = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (f && room.tag == "start")
        {
            ms.bossSound();
            animator.SetInteger("next", 2);
            f = false;
        }
	}
    private void OnDestroy()
    {
        ms.stopSound();
    }
}
