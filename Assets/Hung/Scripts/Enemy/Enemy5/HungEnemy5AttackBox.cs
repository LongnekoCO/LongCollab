using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************
Author Name: Le Hoang Hung
Date: 20/10/2021
Object holding the script: Enemy5AttackBox
Summary:
Enemy attack hit box

Change log:

*******************************************************/


public class HungEnemy5AttackBox : MonoBehaviour
{
    private HungEnemy5Patrol enemyPatrolScript;
    private HungPlayer playerScript;
    public Rigidbody2D arrow;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        enemyPatrolScript = GameObject.Find("Enemy5").GetComponent<HungEnemy5Patrol>();

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
