using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float health = 100;
    private const float maxHealth = 100;
    [SerializeField]
    private float speed = 4;

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
        health -= damage;
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

    public float GetHealth()
    {
        return health;
    }
}
