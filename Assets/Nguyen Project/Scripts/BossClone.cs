using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossClone : MonoBehaviour
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
    private BossCloneSpawn bossScript;

    //Enemy health
    public int bossHP;
    private int bossCurrentHP;

    public Transform player;

    [SerializeField]
    float bossSight;


    // Start is called before the first frame update
    void Start()
    {
        bossScript = GameObject.Find("Boss1").GetComponent<BossCloneSpawn>();
        anim = this.GetComponent<Animator>(); //get access to the animation
        rb2d = this.GetComponent<Rigidbody2D>(); //get access to the Rigidbody2D
        collide2D = this.GetComponent<BoxCollider2D>(); //get access to the BoxCollider2D
        anim.SetTrigger("Walk");
        //bossHP = bossCurrentHP;
        //StartCoroutine(TeleportRoutine());
        //bossScript = GetComponent<BossCloneSpawn>();
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
        //if (distToPlayer < bossSight)
       // {
            //code to chase player
            //ChasePlayer();
        //}
        //else
        //{
            //stop chasing player
           // StopChasingPlayer();
        //}
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
   

    public void Death()
    {
        anim.SetTrigger("Dead");
        bossScript.numberOfClones--;

        //Enemy will be destroyed after the death
        Destroy(this.gameObject, 1.4f);
    }

    
    /*
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
    
    */
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            canMove = false;
            StartCoroutine(Blink());

            //Death();
        }

        /*
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("CollidingWithPlayer");
            canMove = false;
            
        }
        */
    }

    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        Death();

    }
    
}
