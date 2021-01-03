using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Slider slider;
    public Gradient gradient;

    public Image fillHPBar;
    public void setMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        setHealth(maxHealth);
    }
    public void setHealth(int health)
    {
        slider.value = health;

        fillHPBar.color = gradient.Evaluate(slider.normalizedValue);
    }
}
