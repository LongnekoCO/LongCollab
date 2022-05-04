using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************
Author Name: Le Hoang Hung
Date: 1/11/2021
Object holding the script: BossAttackBox
Summary:
Boss attack with fireball, lightning, whirlwind, iceball, laser

Change log:


*******************************************************/

public class HungBossAttackBox : MonoBehaviour
{
    private HungBossPatrol bossScript;

    //Variable for fireball
    public GameObject fireballPrefab;
    public Rigidbody2D fireballRb2d;
    public float fireballSpeed;
    public float fireballShootDelay;

    //Variable for whirlwind
    public GameObject whirlwindPrefab;
    public Rigidbody2D whirlwindRb2d;
    public float whirlwindSpeed;
    public float whirlwindShootDelay;

    //Variable for lightning
    public List<GameObject> lightningStrike;
    public GameObject lightningPrefab;
    public float lightningDelay;

    //Variable for iceball
    public GameObject iceballPrefab;
    public Rigidbody2D iceballRb2d;
    public float iceballSpeed;
    public float iceballShootDelay;

    public float timeStart;

    private bool facingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        bossScript = GameObject.Find("Boss1").GetComponent<HungBossPatrol>();
        //InvokeRepeating("EnemyLaserShoot", timeStart, fireballShootDelay); //laser time to shoot
        //InvokeRepeating("EnemyFireball", timeStart, fireballShootDelay); //fireball time to shoot
        //InvokeRepeating("EnemyLightning", timeStart, lightningDelay); //lighting strike time
        //InvokeRepeating("EnemyWhirlwind", timeStart, whirlwindShootDelay); //whirlwind time to shoot
        //InvokeRepeating("EnemyIceball", timeStart, iceballShootDelay); //iceball time to shoot
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Called in Start()
    public void EnemyFireball()
    {
        //Make a fireball
        //Rigidbody2D latestBall = Instantiate(fireballRb2d, this.transform.position, this.transform.rotation);

        //Make sure a boss is facing right
        if (bossScript.facingRight == true)
        {
            Rigidbody2D latestBall = Instantiate(fireballRb2d, this.transform.position, this.transform.rotation);

            latestBall.AddRelativeForce(new Vector2(500, 0) * fireballSpeed);
        }
        else
        {
            Rigidbody2D latestBall = Instantiate(fireballRb2d, this.transform.position, this.transform.rotation);

            latestBall.AddRelativeForce(new Vector2(-500, 0) * fireballSpeed);
        }
    }

    //Called by BossPatrol.Flip()
    public void FireballFlip()
    {
        //Debug.Log("flip");
        Vector2 ballFlip = fireballPrefab.transform.localScale;
        ballFlip.x = ballFlip.x * -1;
        fireballPrefab.transform.localScale = ballFlip;
        facingRight = !facingRight;
    }

    //Called in Start()
    public void EnemyLightning()
    {
        //Make a random number to spawn the lightning
        int rand = Random.Range(0, 3);
        if (rand == 0)
        {
            Instantiate(lightningPrefab, lightningStrike[0].transform.position, Quaternion.identity);
            //Debug.Log("strike");
        }
        else if (rand == 1)
        {
            Instantiate(lightningPrefab, lightningStrike[1].transform.position, Quaternion.identity);
            //Debug.Log("strike");
        }
        else if (rand == 2)
        {
            Instantiate(lightningPrefab, lightningStrike[2].transform.position, Quaternion.identity);
            //Debug.Log("strike");
        }
    }

    //Called in Start()
    public void EnemyWhirlwind()
    {
        //Make a whirlwind
        Rigidbody2D latestProjectile = Instantiate(whirlwindRb2d, this.transform.position, this.transform.rotation);

        //Whenever a boss is facing
        if (bossScript.facingRight == true)
        {
            //Debug.Log("bullet flip");
            latestProjectile.AddRelativeForce(new Vector2(250, 0) * whirlwindSpeed);
        }
        else
        {
            latestProjectile.AddRelativeForce(new Vector2(-250, 0) * whirlwindSpeed);
        }
    }

    //Called in Start()
    public void EnemyIceball()
    {
        //Make sure a boss is facing right
        if (bossScript.facingRight == true)
        {
            //Make a iceeball
            Rigidbody2D latestBall = Instantiate(iceballRb2d, this.transform.position, this.transform.rotation);

            //Debug.Log("bullet flip");
            latestBall.AddRelativeForce(new Vector2(500, 0) * iceballSpeed);
        }
        else
        {
            //Make a iceeball
            Rigidbody2D latestBall = Instantiate(iceballRb2d, this.transform.position, this.transform.rotation);

            latestBall.AddRelativeForce(new Vector2(-500, 0) * iceballSpeed);
        }
    }

    //Called by BossPatrol.Flip()
    public void IceballFlip()
    {
        //Debug.Log("flip");
        Vector2 ballFlip = iceballPrefab.transform.localScale;
        ballFlip.x = ballFlip.x * -1;
        iceballPrefab.transform.localScale = ballFlip;
        facingRight = !facingRight;
    }
}
