using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour {

    public Slider slider;
    public void setMaxAmmo(int maxAmmo)
    {
        slider.maxValue = maxAmmo;
        setAmmo(maxAmmo);
    }
    public void setAmmo(int ammo)
    {
        slider.value = ammo;
    }
}
