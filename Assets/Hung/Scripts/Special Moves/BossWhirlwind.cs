using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************
Author Name: Le Hoang Hung
Date: 22/11/2021
Object holding the script: BossAttackBox
Summary:
The whirlwind attack damage
Slower than fireball, but boss has more speed

Change log:


*******************************************************/

public class BossWhirlwind : MonoBehaviour
{
    private HungBossPatrol bossScript; //a reference to BossPatrol script
    public Rigidbody2D rb2d;
    public float speed;
    public float shootDelay;
    public float timeStart;

    // Start is called before the first frame update
    void Start()
    {
        bossScript = GameObject.Find("Boss1").GetComponent<HungBossPatrol>(); //access the BossPatrol script
        InvokeRepeating("WhirlwindShoot", timeStart, shootDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WhirlwindShoot()
    {
        //Make a whirlwind
        Rigidbody2D latestProjectile = Instantiate(rb2d, this.transform.position, this.transform.rotation);

        //Whenever a boss is facing
        if (bossScript.facingRight == true)
        {
            //Debug.Log("bullet flip");
            latestProjectile.AddRelativeForce(new Vector2(250, 0) * speed);
        }
        else
        {
            latestProjectile.AddRelativeForce(new Vector2(-250, 0) * speed);
        }
    }
}
