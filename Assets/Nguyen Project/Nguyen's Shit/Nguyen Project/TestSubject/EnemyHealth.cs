using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 300;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void TakeDamage(float dam)
    {
        health -= dam;
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
