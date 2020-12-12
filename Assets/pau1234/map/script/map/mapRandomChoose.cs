using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapRandomChoose : MonoBehaviour {
    System.Random r;
    public GameObject[] maps;
	// Use this for initialization
	void Awake() {
        r = new System.Random(System.Guid.NewGuid().GetHashCode());
        Instantiate<GameObject>(maps[r.Next(maps.Length)], transform);
	}
}
