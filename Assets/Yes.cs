using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yes : MonoBehaviour, IDamageable
{
    private float health = 100;
    public void Damage(float damage)
    {
        if ((health -= damage) <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Death()
    {
        throw new System.NotImplementedException();
    }

    public void GiveHealth(float h)
    {
        Debug.Log("Slowed");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
