using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour {
    private CameraShake cameraShake;

    public int maxHP;
    public int maxShield;

    private int shield;
    private bool selfDamage;

    public bool inCombat;
    private int shieldChargeSpeed;
    private float inCombatTime, combatTagTime;

    private HealthBar healthBar;
    private ShieldBar shieldBar;
    private void Awake()
    {
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();

        healthBar = FindObjectOfType<HealthBar>();
        shieldBar = FindObjectOfType<ShieldBar>();
        combatTagTime = 5f;

        hp = maxHP;
        shield = maxShield;

        healthBar.setMaxHealth(maxHP);
        shieldBar.setMaxShield(maxShield);
    }
    private void Update() {
        // Debug.Log("HP: "+hp+" Shield: "+shield);
        if (!selfDamage && Input.GetKeyDown(KeyCode.M))
        {
            hp -= 1;
            selfDamage = true;
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            selfDamage = false;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            hp += 1;
        }

        if (inCombat == true && inCombatTime < Time.time)
        {
            inCombat = false;
            StartCoroutine(chargeShield());
        }
    }
    private int hpSpace;
    private int _HP
    {
        get
        {
            if (hpSpace > maxHP)
                return maxHP;
            else if (hpSpace < 0)
                return 0;
            else
                return hpSpace;
        }
        set { hpSpace = value; }
    }
    public int hp
    {
        get { return _HP; }
        set
        {
            if (value - hp < 0)
            {
                hitEffect();
            }

            inCombat = true;
            inCombatTime = Time.time + combatTagTime;
            if ((value - hp) < 0 && shield > 0) // damage shield
                shield += value - hp;
            else if ((value - hp) > 0) // arithmetic operation on hp
                _HP += value - hp;
            else // assign hp
                _HP = value;

            healthBar.setHealth(hp);
            shieldBar.setShield(shield);
        }
    }
    public void hurt(int damage)
    {
        hp -= damage;
    }
    IEnumerator chargeShield()
    {
        yield return new WaitForSeconds(1);
        if (shield < maxShield && inCombat == false) 
        {
            shield += maxShield / 5;
            shieldBar.setShield(shield);
            StartCoroutine(chargeShield());
        }
    }
    private void hitEffect()
    {
        GetComponent<AudioSource>().PlayOneShot(GetComponent<SFX>().hit);
        StartCoroutine(cameraShake.shakeCamera(.15f, .4f));
    }
}
