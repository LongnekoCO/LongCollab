using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float walkingSpeed = 0.09f;
    public bool facingRight = true;
    //Animator anim;
    public Rigidbody2D playerRigidbody;


    //public int health = 20; //testing only

    public int health = 100; //testing only

    public int currentHealth;
    public HungHealthBar healthBar;

    public float jumpForce;
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundlayer;
    public bool canMovee = true;
    public GameObject log;
    public GameObject smokeParticle;
    //public GameObject bow;
    //public Transform pos1, pos2;
    public float speed;
    public GameObject Boss;
    //public Transform starPos;

    float doubleTapTime;
    KeyCode lastKeyCode;

    public float dashSpeed;
    private float dashCount;
    public float startDashCount;
    private int side;
    public bool canDash;
    public bool parachuteOn;

    private int extraJumps;
    public int extraJumpsVal;

    public Transform parachute;

    public bool enterPool = true;

    public PlayerBowAndPowers powerScript;

    private float moveInput;

    public GameObject unitRoot;
    Animator anim;

    public bool isTouchingFront;
    public Transform frontCheck;
    public bool wallSliding;
    public float wallSlidingSpeed;

    public bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;



    // Start is called before the first frame update
    void Start()
    {
        //anim = this.GetComponent<Animator>();
        canMovee = true;
        //bow.SetActive(false);

        unitRoot = this.transform.Find("UnitRoot").gameObject;
        if (unitRoot != null)
        {
            anim = unitRoot.GetComponent<Animator>();
        }


        dashCount = startDashCount;
        canDash = true;

        parachute.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);

        currentHealth = health;
        healthBar.SetMaxHealth(health);

        powerScript = this.GetComponent<PlayerBowAndPowers>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement();
        Dashee();
        if (isGrounded)
        {
            extraJumps = extraJumpsVal;
            if (Input.GetKeyDown(KeyCode.LeftShift) && parachuteOn == true)
            {
                parachuteOn = false;
                parachute.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            Jump();
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            Jump();
        }

        if (!isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt) && parachuteOn == false)
            {
                parachuteOn = true;
            }
            else if (Input.GetKeyDown(KeyCode.LeftAlt) && parachuteOn == true)
            {
                parachuteOn = false;
            }
        }

        if (parachuteOn == true)
        {
            GetComponent<Rigidbody2D>().drag = 12;
            parachute.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        else if (parachuteOn == false)
        {
            GetComponent<Rigidbody2D>().drag = 0;
            parachute.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, 0.2f, groundlayer);

        if (isTouchingFront == true && isGrounded == false && moveInput == 0)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }



        WallSliding();
        WallJumping();

           

    }

    void FixedUpdate()
    {
        //checks if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);

        Movement2();
        


    }

    void WallSliding()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(wallSliding == true)
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, Mathf.Clamp(playerRigidbody.velocity.y, -wallSlidingSpeed, float.MaxValue));
            }            
        }
       
    }

    void WallJumping()
    {
        if (Input.GetKey(KeyCode.Space) && wallSliding == true)
        {
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }

        else if (Input.GetKeyUp(KeyCode.Space) || wallSliding == false)
        {
            wallJumping = false;
        }
        
        if (wallJumping == true)
        {
            playerRigidbody.velocity = new Vector2(xWallForce * -moveInput, yWallForce);
        }

    }

    void Movement2()
    {
        if (canMovee == true)
        {
            moveInput = Input.GetAxis("Horizontal") * walkingSpeed ;
            playerRigidbody.velocity = new Vector2(moveInput , playerRigidbody.velocity.y);
            anim.SetFloat("movement", Mathf.Abs(moveInput));
            if (facingRight == true && moveInput < 0)
            {
                Flip();
            }

            else if (facingRight == false && moveInput > 0)
            {
                Flip();
            }
            
            

        }
      
    }

    IEnumerator Dash()
    {
        Debug.Log("Eurobeat Intensified");
        canDash = false;
        walkingSpeed = walkingSpeed * 3;
        anim.SetTrigger("isRunning");
        yield return new WaitForSeconds(0.15f);
        walkingSpeed = walkingSpeed/3;
        canDash = true;

       
    }

    void Jump()
    {
        playerRigidbody.velocity = Vector2.up * jumpForce;        

    }

    void Dashee()
    {
        if (canMovee == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) && canDash == true)
            {
                if(powerScript.currentEnergy - 20 >= 0)
                {
                    Vector3 temp = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
                    powerScript.UseEnergy(20);
                    Instantiate(log, temp, Quaternion.identity);
                    Instantiate(smokeParticle, temp, Quaternion.identity);
                    StartCoroutine(Dash());

                }

            }

            
        }
            
    }

    //void Movement()
    //{
    //    Vector3 playerPosition = this.transform.position;
    //    playerPosition.z = 1;

    //    if(canMovee == true)
    //    {
    //        if (Input.GetKey(KeyCode.D))
    //        {
    //            playerPosition.x = playerPosition.x + walkingSpeed;
    //            this.transform.position = playerPosition;
    //            //anim.SetTrigger("isWalking");
    //            if (facingRight == false)
    //            {
    //                Flip();
    //                //bow1.Flip();
    //            }
                
    //            if (Input.GetKeyDown(KeyCode.RightShift) && canDash == true)
    //            {
    //                Vector3 temp = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    //                powerScript.UseEnergy(20);
    //                Instantiate(smokeParticle, temp, Quaternion.identity);
    //                StartCoroutine(Dash());

    //            }
    //        }

    //        else if (Input.GetKey(KeyCode.A))
    //        {
    //            playerPosition.x = playerPosition.x - walkingSpeed;
    //            this.transform.position = playerPosition;
    //           // anim.SetTrigger("isWalking");

    //            if (facingRight == true)
    //            {
    //                Flip();
    //                //bow1.Flip();
    //            }

    //            if (Input.GetKeyDown(KeyCode.RightShift) && canDash == true)
    //            {
    //                if (powerScript.currentEnergy - 20 >= 0)
    //                {
    //                    Vector3 temp = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    //                    Instantiate(smokeParticle, temp, Quaternion.identity);
    //                    powerScript.UseEnergy(20);
    //                    StartCoroutine(Dash());
    //                }
                    
    //            }
    //        }
    //        else
    //        {
    //            //anim.SetTrigger("isIdle");
    //        }
    //    }

    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        if(powerScript.currentEnergy - 20 >= 0)
    //        {
    //            if (facingRight == true)
    //            {
    //                //int positionX = Random.Range(1,10);
    //                Vector3 temp = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    //                Vector3 newPos = new Vector3(this.transform.position.x + 4, this.transform.position.y, this.transform.position.z);
    //                this.transform.position = newPos;
    //                Instantiate(log, temp, Quaternion.identity);
    //                Instantiate(smokeParticle, temp, Quaternion.identity);
    //                //Destroy(log, 2f);
    //            }
    //            else if (facingRight == false)
    //            {
    //                //int positionX = Random.Range(1,10);
    //                Vector3 temp = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    //                Vector3 newPos = new Vector3(this.transform.position.x - 4, this.transform.position.y, this.transform.position.z);
    //                this.transform.position = newPos;
    //                Instantiate(log, temp, Quaternion.identity);
    //                Instantiate(smokeParticle, temp, Quaternion.identity);
    //                //Destroy(log, 2f);
    //            }
    //            powerScript.UseEnergy(20);
    //        }
    //   }
    //}

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 playerScale = this.transform.localScale;
        playerScale.x = playerScale.x * -1;
        this.transform.localScale = playerScale;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BossTrigger")
        {
            Boss.SetActive(true);
        }
 
        else if (col.gameObject.tag == "PoisonPool")
        {
            if(enterPool == true)
            {
                StartCoroutine(PoisonPool());
                health -= 1;
            }

        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void GetHealth(int health1)
    {
        currentHealth += health1;
        healthBar.SetHealth(currentHealth);
    }

    IEnumerator PoisonPool()
    {
        enterPool = false;
        yield return new WaitForSecondsRealtime(1f);
        enterPool = true;
    }
}
