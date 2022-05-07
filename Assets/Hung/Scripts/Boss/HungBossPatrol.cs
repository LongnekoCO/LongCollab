using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*******************************************************
Author Name: Le Hoang Hung
Date: 1/11/2021
Object holding the script: Boss1
Summary:
Boss movement, attack, animation, health

Change log:
Change the movement of enemy
Change the attack

*******************************************************/

public class HungBossPatrol : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb2d;
    private Collider2D collide2D;
    private HungFireball fireballScript; //a reference to Fireball script
    private HungIceball iceballScript; //a reference to Iceball script

    public float bossMoveSpeed;
    public Transform target;
    public bool facingRight = true;
    public bool isMoving = true;

    //Enemy attack
    public GameObject bossAttackBox;
    public int bossAttackDamage;

    //Enemy health
    public int bossHP; //boss health
    private int bossCurrentHP = 100; //boss current health

    public Transform player;

    [SerializeField]
    float bossSight; //the sight that boss can see

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>(); //get access to the animation
        rb2d = this.GetComponent<Rigidbody2D>(); //get access to the Rigidbody2D
        collide2D = this.GetComponent<BoxCollider2D>(); //get access to the BoxCollider2D
        fireballScript = GameObject.Find("BossAttackBox").GetComponent<HungFireball>(); //get access to Fireball script
        iceballScript = GameObject.Find("BossAttackBox").GetComponent<HungIceball>(); //get access to Iceball script

        //boss health
        bossHP = bossCurrentHP;
        //StartCoroutine(TeleportRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        float enemyMove = bossMoveSpeed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, enemyMove);

        //distance to player
        float distToPlayer = Vector2.Distance(this.transform.position, player.position);

        //Debug.Log(distToPlayer);
        if (distToPlayer < bossSight)
        {
            //code to chase player
            ChasePlayer();
        }
        else
        {
            //stop chasing player
            StopChasingPlayer();
        }
    }

    //Enemy will turn around after hit the waypoint
    //Called in Update()
    public void Flip()
    {
        Vector2 enemyFilp = this.transform.localScale;
        enemyFilp.x = enemyFilp.x * -1;
        this.transform.localScale = enemyFilp;
        facingRight = !facingRight;

        //The fireball flip
        fireballScript.FireballFlip();

        //The iceball flip
        iceballScript.IceballFlip();
    }

    //Called by ****
    public void Attack()
    {
        //Enemy will attack with different animations
        int attackRand = Random.Range(0, 3);
        if (attackRand == 0)
        {

        }
        else if (attackRand == 1)
        {
;
        }
        else if (attackRand == 2)
        {

        }
        anim.SetTrigger("Walk");
    }

    //Called by ****
    public void TakeDamage(int damage)
    {
        //Boss will take damage
        bossCurrentHP = bossCurrentHP - damage;
        //anim.SetTrigger("Hit");

        //When the boss is out of health
        if (bossCurrentHP <= 0)
        {
            Death();
        }
    }

    //Called by TakeDamage()
    public void Death()
    {
        anim.SetTrigger("Dead");

        //Enemy will be destroyed after the death
        Destroy(this.gameObject, 2f);
    }

    //Boss will chase the player
    //Called in Update()
    void ChasePlayer()
    {
        if (this.transform.position.x < player.position.x)
        {
            //enemy is to the left side of the player, so move right
            rb2d.velocity = new Vector2(bossMoveSpeed, 0);
        }
        else
        {
            //enemy is to the left side of the player, so move left
            rb2d.velocity = new Vector2(-bossMoveSpeed, 0);
        }
    }

    //Whenever boss is far away to player
    //Called in Update()
    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }

    /*void Teleport()
    {
        int positionX = Random.Range(-9, 1);
        Vector3 temp = new Vector3(positionX, this.transform.position.y, this.transform.position.z);
        //StartCoroutine(Teleport());
        this.transform.position = temp;
        anim.SetTrigger("TeleportOut");
    }

    IEnumerator TeleportRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        Teleport();
    }*/
}
