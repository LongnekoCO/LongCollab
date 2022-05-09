using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************
Author Name: Le Hoang Hung
Date: 20/10/2021
Object holding the script: Enemy5
Summary:
Enemy movement, attack, animation

Change log:
Change the movement of enemy

*******************************************************/

public class HungEnemy5Patrol : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb2d;
    private Collider2D collide2D;

    public Transform player;
    public HungHealthBar healthBar;

    public float enemyMoveSpeed;
    public float enemyRealMoveSpeed;
    public Transform target;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    private bool isMoving;
    public bool facingRight = true;

    //Enemy attack
    public GameObject enemyAttackBox;
    public int enemyAttackDamage;

    //Enemy health
    public int enemyHP;
    public int enemyMaxHP = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>(); //get access to the animation
        rb2d = this.GetComponent<Rigidbody2D>(); //get access to the Rigidbody2D
        collide2D = this.GetComponent<BoxCollider2D>(); //get access to the BoxCollider2D
        anim.SetTrigger("Walk");
        enemyHP = enemyMaxHP;
        healthBar.SetMaxHealth(enemyHP);
        enemyMoveSpeed = enemyRealMoveSpeed;
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == true)
        {
            Move();
        }
        
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Damage(20);
        }*/
    }

    //Enemy movement
    //Called in Update()
    public void Move()
    {
        anim.SetTrigger("Walk");
        float enemyMove = enemyMoveSpeed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, enemyMove);
        enemyMoveSpeed = enemyRealMoveSpeed;
    }

    //Enemy will turn around after hit the waypoint
    //Called by Move() when enemy turning
    public void Flip()
    {
        Vector2 enemyFilp = this.transform.localScale;
        enemyFilp.x = enemyFilp.x * -1;
        this.transform.localScale = enemyFilp;
        facingRight = !facingRight;
    }

    //Called by EnemyAttackBox.OnTriggerEnter2D()
    public void Attack()
    {
        anim.SetTrigger("Attack1");
        enemyMoveSpeed = 0;

        //Enemy will attack with different animations
        /*int attackRand = Random.Range(0, 3);
        if (attackRand == 0)
        {
            anim.SetTrigger("Attack1");
        }
        else if (attackRand == 1)
        {
            anim.SetTrigger("Attack2");
        }*/
    }

    public void ArrowShoot1()
    {
        if (facingRight == true)
        {
            Rigidbody2D latesetArrow = Instantiate(enemyAttackBox.GetComponent<HungEnemy5AttackBox>().arrow, enemyAttackBox.GetComponent<HungEnemy5AttackBox>().gameObject.transform.position, Quaternion.identity);

            latesetArrow.AddRelativeForce(new Vector2(500, 0) * enemyAttackBox.GetComponent<HungEnemy5AttackBox>().speed);
        }
        else
        {
            Rigidbody2D latesetArrow = Instantiate(enemyAttackBox.GetComponent<HungEnemy5AttackBox>().arrow, enemyAttackBox.GetComponent<HungEnemy5AttackBox>().gameObject.transform.position, Quaternion.identity);

            latesetArrow.AddRelativeForce(new Vector2(-500, 0) * enemyAttackBox.GetComponent<HungEnemy5AttackBox>().speed);
        }
    }

    public void ArrowShoot2()
    {
        if (facingRight == true)
        {
            Rigidbody2D latesetArrow = Instantiate(enemyAttackBox.GetComponent<HungEnemy5AttackBox>().arrow, enemyAttackBox.GetComponent<HungEnemy5AttackBox>().gameObject.transform.position, Quaternion.identity);

            latesetArrow.AddRelativeForce(new Vector2(500, -500) * enemyAttackBox.GetComponent<HungEnemy5AttackBox>().speed);
        }
        else
        {
            Rigidbody2D latesetArrow = Instantiate(enemyAttackBox.GetComponent<HungEnemy5AttackBox>().arrow, enemyAttackBox.GetComponent<HungEnemy5AttackBox>().gameObject.transform.position, Quaternion.identity);

            latesetArrow.AddRelativeForce(new Vector2(-500, -500) * enemyAttackBox.GetComponent<HungEnemy5AttackBox>().speed);
        }
    }

    public void Damage(int damage)
    {
        enemyHP -= damage;

        healthBar.SetHealth(enemyHP);

        anim.SetTrigger("Hit");

        if (enemyHP <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        anim.SetTrigger("Dead");

        enemyMoveSpeed = 0;

        //Enemy will be destroyed after the death
        Destroy(this.gameObject, 2f);
    }
}
