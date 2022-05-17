using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************
Author Name: Le Hoang Hung
Date: 20/10/2021
Object holding the script: List of waypoint
Summary:
The target that enemy and boss will change direction

Change log:

*******************************************************/

public class HungWaypoint : MonoBehaviour
{
    public List<Transform> target = new List<Transform>(); //list of waypoints

    //private HungBossPatrol bossPatrol; //a reference to BossPatrol script
    //private HungEnemyPatrol enemyPatrol1;
    //private HungEnemy2Patrol enemyPatrol2;
    //private HungEnemyPatrol enemyPatrol3;
    //private HungEnemyPatrol enemyPatrol4;
    //private HungEnemy5Patrol enemyPatrol5;

    // Start is called before the first frame update
    void Start()
    {     
        //bossPatrol = GameObject.Find("Boss1").GetComponent<HungBossPatrol>();
        //enemyPatrol1 = GameObject.Find("Enemy1").GetComponent<HungEnemyPatrol>();
        //enemyPatrol2 = GameObject.Find("Enemy2").GetComponent<HungEnemy2Patrol>();
        //enemyPatrol3 = GameObject.Find("Enemy3").GetComponent<HungEnemyPatrol>();
        //enemyPatrol4 = GameObject.Find("Enemy4").GetComponent<HungEnemyPatrol>();
        //enemyPatrol5 = GameObject.Find("Enemy5").GetComponent<HungEnemy5Patrol>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Call the GetRandomTarget()
            //collision.gameObject.GetComponent<HungEnemyPatrol>().target = GetRandomTarget();
            //collision.gameObject.GetComponent<HungEnemy2Patrol>().target = GetRandomTarget();
            //collision.gameObject.GetComponent<HungBossPatrol>().target = GetRandomTarget();

            //collision.gameObject.GetComponent<HungEnemyPatrol>().Flip();
            //collision.gameObject.GetComponent<HungEnemy2Patrol>().Flip();
            //collision.gameObject.GetComponent<HungBossPatrol>().Flip();
        }
    }

    private Transform GetRandomTarget()
    {
        int rand = Random.Range(0, target.Count);
        
        //Get the new target to null
        Transform newTarget = null;

        newTarget = target[rand];

        return newTarget;
    }
}
