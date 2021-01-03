using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWeapons : MonoBehaviour {
    public void setImage(Sprite sp)
    {
        gameObject.GetComponent<Image>().sprite = sp;
    }
}
