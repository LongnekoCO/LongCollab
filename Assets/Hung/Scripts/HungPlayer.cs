using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************
Author Name: Le Hoang Hung
Date: 22/11/2021
Object holding the script: Player
Summary:
The player example

Change log:

*******************************************************/

public class HungPlayer : MonoBehaviour
{
    public int playerHealth = 100;
    public int playerCurrentHealth;
    public float moveSpeed;
    public bool isMoving = true;
    private HungWhirlwindHit whirlwindHit;
    public GameObject windPraticle;
    public GameObject lightningPraticle;
    public HungHealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        //Player startup health
        playerCurrentHealth = playerHealth;
        healthBar.SetMaxHealth(playerCurrentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Whirlwind")
        {
            //Debug.Log("collide");
            GameObject windEffect = Instantiate(windPraticle, this.transform.position, Quaternion.identity);
            Destroy(windEffect, whirlwindHit.timeLimited);
            //StartCoroutine(WindEffect());
        }
        else if (collision.gameObject.tag == "Lightning")
        {
            Instantiate(lightningPraticle, this.transform.position, Quaternion.identity);
        }
    }

    //Called by Fireball.OnTriggerEnter2D() when take damage
    //Called by Lightning.OnTriggerEnter2D() when take damage
    //Called by Whirlwind.OnTriggerEnter2D() when take damage
    //Called by Iceball.OnTriggerEnter2D() when take damage
    //Called by Glue.OnCollisionEnter2D() when take damage
    public void TakeDamage(int damage)
    {
        playerCurrentHealth -= damage;
        healthBar.SetHealth(playerCurrentHealth);
    }

    IEnumerator WindEffect()
    {
        windPraticle.SetActive(true);
        yield return new WaitForSeconds(whirlwindHit.timeLimited);
        windPraticle.SetActive(false);
    }
}
