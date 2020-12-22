using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestry : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
