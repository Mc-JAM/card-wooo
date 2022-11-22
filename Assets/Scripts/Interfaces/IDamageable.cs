using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void Damage(float damage);
    public void Death();
    public void GiveHealth(float h); //This is used to slow enemies, h is the slow effect
}
