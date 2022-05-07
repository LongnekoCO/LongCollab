using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************
Author Name: Le Hoang Hung
Date: 22/11/2021
Object holding the script: BossAttackBox
Summary:
The fire attack damage

Change log:


*******************************************************/

public class HungFireball : MonoBehaviour
{
    private HungBossPatrol bossScript;
    public Rigidbody2D rb2d;
    public float speed;
    public float shootDelay;
    public float timeStart;
    public bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        bossScript = GameObject.Find("Boss1").GetComponent<HungBossPatrol>();
        InvokeRepeating("FireballShoot", timeStart, shootDelay); //fireball time to shoot
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireballShoot()
    {
        //Make sure a boss is facing right
        if (bossScript.facingRight == true)
        {
            //Make a fireball
            Rigidbody2D latestBall = Instantiate(rb2d, this.transform.position, this.transform.rotation);

            latestBall.AddRelativeForce(new Vector2(500, 0) * speed);
        }
        else
        {
            //Make a fireball
            Rigidbody2D latestBall = Instantiate(rb2d, this.transform.position, this.transform.rotation);

            latestBall.AddRelativeForce(new Vector2(-500, 0) * speed);
        }
    }

    //Called by BossPatrol.Flip()
    public void FireballFlip()
    {
        //Debug.Log("flip");
        Vector2 ballFlip = rb2d.transform.localScale;
        ballFlip.x = ballFlip.x * -1;
        rb2d.transform.localScale = ballFlip;
        facingRight = !facingRight;
    }
}
