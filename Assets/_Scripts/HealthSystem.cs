using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem 
{
    public event EventHandler onHealthChanged;
    private int health;
    private int healthMax;

  public HealthSystem(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }
    public int GetHealth()
    {
        return health;
    }
    public float getHealthPercent()
    {
        return (float)health / healthMax;
    }
    public void Damage(int damageHealth)
    {
        health -= damageHealth;
        if (health < 0) health = 0;

        if (onHealthChanged != null) onHealthChanged(this, EventArgs.Empty);
    }
    public void Heal(int healAmmount)
    {
        health += healAmmount;
        if (health > healthMax) health = healthMax;
        if (onHealthChanged != null) onHealthChanged(this, EventArgs.Empty);

    }
}
