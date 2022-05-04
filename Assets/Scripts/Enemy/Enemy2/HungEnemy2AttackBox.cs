using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************
Author Name: Le Hoang Hung
Date: 20/10/2021
Object holding the script: Enemy2AttackBox
Summary:
Enemy attack hit box

Change log:

*******************************************************/


public class HungEnemy2AttackBox : MonoBehaviour
{
    private HungEnemy2Patrol enemyPatrolScript;
    private HungPlayer playerScript; 

    // Start is called before the first frame update
    void Start()
    {
        enemyPatrolScript = GameObject.Find("Enemy2").GetComponent<HungEnemy2Patrol>();
        
        playerScript = GameObject.Find("Player").GetComponent<HungPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyPatrolScript.Attack();
            playerScript.TakeDamage(enemyPatrolScript.enemyAttackDamage);
        }
    }
}
