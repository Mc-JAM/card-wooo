using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float health = 100, shield = 100, maxShield = 100;
    private const float maxHealth = 100;
    [SerializeField]
    private float speed = 4;
    public float mass = 65.00f;

    private SimpleGM simpleGM;


    // Start is called before the first frame update
    void Start()
    {
        simpleGM = SimpleGM.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void Damage(float damage)
    {
        float damageToHealth;
        try
        {
            damageToHealth = damage * (shield / maxShield);
            shield -= damageToHealth;
            damageToHealth = damage - damageToHealth;
        }
        catch
        {
            damageToHealth = damage;
        }
        health -= damageToHealth;
        if (health > 0) return;
        Death();
    }

    public void Death()
    {
        simpleGM.GameOver();
    }

    public void GiveHealth(float h)
    {
        health = Mathf.Clamp(health + h, 0, maxHealth);
    }
}
