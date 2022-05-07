using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongPlantBoss : MonoBehaviour
{
    public int bossHP;

    public int bossMaxHP;

    public int damageTaken;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        bossHP -= damageTaken;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Attack")
        {
            TakeDamage();
        }
    }
}
