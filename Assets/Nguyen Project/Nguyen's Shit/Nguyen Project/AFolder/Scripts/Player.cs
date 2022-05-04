using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Player : MonoBehaviour
{
    float walkingSpeed = 0.05f;
    public bool facingRight = true;
    Animator anim;
    public Rigidbody2D playerRigidbody;
    public int health = 20; //testing only
    public float jumpForce;
    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundlayer;
    public GameObject Boss;
    private BossPatrol bossScipt;
    public bool isLevitated = false;
    public bool canMovee = true;
    public float timer = 1f;
    public GameObject log;
    public GameObject smokeParticle;
    public bool canMove = true;
    public GameObject boulderDef;
    public GameObject boulderDefSpawn;
    private BoulderDefense boulderDefScript;
    public GameObject boulderAttack;
    public GameObject boulderAttackSpawn;
    public GameObject iceAttack;
    public bool inRange;
    public bool canIce = true;
    public bool canFire = true;
    public GameObject fireSpawn;
    public GameObject fireCollider;
    public GameObject fireParticles;
    public GameObject fireParticlesLeft;
    public GameObject bow; 
    public Transform pos1, pos2;
    public float speed;
    public Transform starPos;
    //GameObject bow1 = gameObject.transform.Find("Bow"); 

    Vector3 nextPos;


    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        bossScipt = this.GetComponent<BossPatrol>();
        //boulderDefScript = GameObject.Find("Boulder").GetComponent<BoulderDefense>();
        boulderDefSpawn.SetActive(false);
        boulderAttackSpawn.SetActive(false);
        canMove = true;
        fireSpawn.SetActive(false);
        fireCollider.SetActive(false);
        bow.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {                
        Movement();
        DeadorHurt();

        if(Input.GetKeyDown(KeyCode.Space) )
        {
            //checks if the player is on the ground to avoid double jump
            if(isGrounded)
            {
                Jump();
            }
            
        }

        

    }

    void FixedUpdate()
    {
        //checks if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f,groundlayer);
    }
    
    //jump
    void Jump()
    {
        playerRigidbody.velocity = Vector2.up * jumpForce;
    }


    //Player Movement 
    void Movement()
    {
        
            Vector3 playerPosition = this.transform.position;
            playerPosition.z = 1;

        if(canMove == true)
        {
            if (Input.GetKey(KeyCode.D))
            {
                playerPosition.x = playerPosition.x + walkingSpeed;
                this.transform.position = playerPosition;
                anim.SetTrigger("isWalking");

                if (facingRight == false)
                {
                    Flip();
                    //bow1.Flip();
                }
            }

            else if (Input.GetKey(KeyCode.A))
            {
                playerPosition.x = playerPosition.x - walkingSpeed;
                this.transform.position = playerPosition;
                anim.SetTrigger("isWalking");

                if (facingRight == true)
                {
                    Flip();
                    //bow1.Flip();
                }
            }

            else if (Input.GetKeyDown(KeyCode.F))
            {
                anim.SetTrigger("isAttack");
            }

            else
            {
                anim.SetTrigger("isIdle");
            }
        }
            

            if (Input.GetKeyDown(KeyCode.Q))
            {
               if(facingRight == true)
                {
                //int positionX = Random.Range(1,10);
                Vector3 temp = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
                Vector3 newPos = new Vector3(this.transform.position.x + 4, this.transform.position.y, this.transform.position.z);
                this.transform.position = newPos;
                Instantiate(log, temp, Quaternion.identity);
                Instantiate(smokeParticle, temp, Quaternion.identity);
                //Destroy(log, 2f);
            }

               else if(facingRight == false)
                {
                //int positionX = Random.Range(1,10);
                Vector3 temp = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
                Vector3 newPos = new Vector3(this.transform.position.x - 4, this.transform.position.y, this.transform.position.z);
                this.transform.position = newPos;
                Instantiate(log, temp, Quaternion.identity);
                Instantiate(smokeParticle, temp, Quaternion.identity);
                //Destroy(log, 2f);
            }


        }

            else if (Input.GetKeyDown(KeyCode.G))
            {
                anim.SetTrigger("isIdle");
                boulderDefSpawn.SetActive(true);
                Instantiate(boulderDef, boulderDefSpawn.transform.position, Quaternion.identity);
                canMove = false;
                StartCoroutine(BoulderFall());
            }

            else if (Input.GetKeyDown(KeyCode.C))
            {
                anim.SetTrigger("isIdle");
                boulderAttackSpawn.SetActive(true);
                Instantiate(boulderAttack, boulderAttackSpawn.transform.position, Quaternion.identity);
                canMove = false;
                StartCoroutine(BoulderAttack());
            }            

            else if (Input.GetKeyDown(KeyCode.V) && inRange == true && canIce == true)
            {
                anim.SetTrigger("isIdle");
                Instantiate(iceAttack, Boss.transform.position, Quaternion.identity);
                StartCoroutine(Ice());
            }

            else if(Input.GetKeyDown(KeyCode.Z))
            {
                if(!bow.activeSelf)
                {
                    bow.SetActive(true);
                }

                else
            {
                bow.SetActive(false);
            }
                                                  
            }
            
           
                   
    }

    IEnumerator FireStart()
    {        
        yield return new WaitForSeconds(0.4f);
        Instantiate(fireParticles, fireSpawn.transform.position, Quaternion.identity);
    }

    IEnumerator FireStartLeft()
    {
        yield return new WaitForSeconds(0.4f);
        Instantiate(fireParticlesLeft, fireSpawn.transform.position, Quaternion.identity);
    }

    IEnumerator FireEnd()
    {
        yield return new WaitForSeconds(2f);
        fireSpawn.SetActive(false);
        fireCollider.SetActive(false);
        canMove = true;
        canIce = true;
        canFire = true;
        anim.SetTrigger("isIdle");
    }

    IEnumerator Ice()
    {
        canIce = false;
        yield return new WaitForSeconds(2f);
        canIce = true;
    }

    IEnumerator BoulderFall()
    {
        yield return new WaitForSeconds(1f);
        boulderDefSpawn.SetActive(false);
        canMove = true;
    }

    IEnumerator BoulderAttack()
    {
        yield return new WaitForSeconds(2f);
        boulderAttackSpawn.SetActive(false);
        canMove = true;
    }
    //Flip from right to left or vice versa
    //Called in Movement()
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 playerScale = this.transform.localScale;
        playerScale.x = playerScale.x * -1;
        this.transform.localScale = playerScale;
    }

    //for testing animation
    void DeadorHurt()
    {
        
            if (health <= 0)
            {
                anim.SetTrigger("isDead");
                StartCoroutine(Dead());
            }

    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
        GetComponent<PlayerMouse>().enabled = false;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "BossTrigger")
        {
            Boss.SetActive(true);
        }

        if(col.gameObject.tag == "Clone")
        {
            anim.SetTrigger("isHurt");
            health -= 1;
        }

        

        
    }
}
