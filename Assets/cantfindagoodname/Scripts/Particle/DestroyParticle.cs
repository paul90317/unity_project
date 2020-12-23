using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class DestroyParticle : MonoBehaviour {

    private ParticleSystem ps;
	void Start () {
        ps = GetComponent<ParticleSystem>();
	}
	void Update () {
        if (ps)
            if (!ps.IsAlive())
                Destroy(gameObject);
	}
}
