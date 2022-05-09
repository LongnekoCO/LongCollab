using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************
Author Name: Le Hoang Hung
Date: 20/10/2021
Object holding the script: Enemy1AttackBox, Enemy2AttackBox, Enemy3AttackBox, Enemy4AttackBox, Enemy5AttackBox
Summary:
Enemy attack hit box

Change log:

*******************************************************/


public class HungEnemy3AttackBox : MonoBehaviour
{
    private HungEnemy3Patrol enemyPatrolScript;
    private HungPlayer playerScript; 

    // Start is called before the first frame update
    void Start()
    {
        enemyPatrolScript = GameObject.Find("Enemy3").GetComponent<HungEnemy3Patrol>();
        
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
