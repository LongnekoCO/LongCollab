using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 300;

    //public float health;
    public float maxHealth = 300f;
    public EnemyHealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {

        health = maxHealth;
        healthBar.SetMaxHealth(health);

    }

    public void TakeDamage(float dam)
    {
        health -= dam;
        healthBar.SetHealth(health);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }
}
