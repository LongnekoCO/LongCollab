using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatrol : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb2d;
    private Collider2D collide2D;

    public float bossMoveSpeed;
    public Transform target;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    private bool facingRight = true;

    //Enemy attack
    public GameObject bossAttackBox;
    public int bossAttackDamage;
    public GameObject bossFireball;
    public GameObject bossLightning;
    public bool canMove = true;
    private BossTeleporter bossScript;
    public bool rinnegan = false;

    //Enemy health
    public int bossHP;
    private int bossCurrentHP;

    public Transform player;

    [SerializeField]
    float bossSight;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>(); //get access to the animation
        rb2d = this.GetComponent<Rigidbody2D>(); //get access to the Rigidbody2D
        collide2D = this.GetComponent<BoxCollider2D>(); //get access to the BoxCollider2D
        anim.SetTrigger("Walk");
        bossHP = bossCurrentHP;
        //StartCoroutine(TeleportRoutine());
        bossScript = this.GetComponent<BossTeleporter>();

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            anim.SetTrigger("Walk");
            float enemyMove = bossMoveSpeed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, enemyMove);
        }


        //distance to player
        float distToPlayer = Vector2.Distance(this.transform.position, player.position);

        //Debug.Log(distToPlayer);
        if (distToPlayer < bossSight)
        {
            //code to chase player
            //ChasePlayer();
        }
        else
        {
            //stop chasing player
            StopChasingPlayer();
        }

        Rinnegan();
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
        //Enemy will attack with different animations
        int attackRand = Random.Range(0, 3);
        if (attackRand == 0)
        {
            anim.SetTrigger("Attack1");
            Fireball(20);
        }
        else if (attackRand == 1)
        {
            anim.SetTrigger("Attack2");
            Lightning(10);
        }
        else if (attackRand == 2)
        {
            anim.SetTrigger("Attack3");
        }
        anim.SetTrigger("Walk");
    }

    public void Death()
    {
        anim.SetTrigger("Dead");

        //Enemy will be destroyed after the death
        Destroy(this.gameObject, 2f);
    }

    public void BossDamage(int damage)
    {
        bossCurrentHP = bossCurrentHP - damage;
        anim.SetTrigger("Hit");
        if (bossCurrentHP <= 0)
        {
            Death();
        }
    }

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

    public void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }

    public void Fireball(int damage)
    {
        Instantiate(bossFireball, this.transform.position, Quaternion.identity);
    }

    public void Lightning(int damage)
    {
        StartCoroutine(LightningRoutine());
    }

    IEnumerator LightningRoutine()
    {
        Instantiate(bossLightning, player.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "HitPoint")
        {
            if(facingRight == true)
            {
                canMove = false;
                rb2d.velocity = new Vector2(3f, 3f);
                //BossDamage(20);
                anim.SetTrigger("Hit");
            }
            else
            {
                canMove = false;
                rb2d.velocity = new Vector2(3f, 3f);
                //BossDamage(20);
                anim.SetTrigger("Hit");
            }
            StartCoroutine(Blink());
        }

        if (col.gameObject.tag == "ShrinkingArrow")
        {
            StartCoroutine(Shrink());
        }

        /*
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("CollidingWithPlayer");
            canMove = false;
            
        }
        */

        if (col.gameObject.tag == "Ice")
        {
            canMove = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ice")
        {
            canMove = true;
        }
    }
    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        canMove = true;
    }

    public void Rinnegan()
    {
        if(rinnegan == true)
        {
            anim.SetTrigger("Rinnegan"); 

        }

        else
        {
            anim.SetTrigger("Walk");
        }
    }

    IEnumerator Shrink()
    {
        Vector3 temp = this.transform.localScale;
        this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        yield return new WaitForSeconds(5f);
        this.transform.localScale = temp;

    }

}
