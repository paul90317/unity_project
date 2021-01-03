using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchClass : MonoBehaviour {
    int current;
    public List<GameObject> classes;
    private void Awake()
    {
        current = 0;
    }
    void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            classes[current].SetActive(false);
            current = (current + 1) % classes.Count;
            classes[current].SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().sprite = classes[current].GetComponent<AbstractClasses>().spr;
        }
	}
}
