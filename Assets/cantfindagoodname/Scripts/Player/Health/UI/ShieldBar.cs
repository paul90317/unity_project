using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour {

    public Slider slider;
    public void setMaxShield(int maxShield)
    {
        slider.maxValue = maxShield;
        setShield(maxShield);
    }
    public void setShield(int shield)
    {
        slider.value = shield;
    }
}
