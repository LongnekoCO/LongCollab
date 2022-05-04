using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    float walkingSpeed = 0.06f;
    private bool facingRight = false;
    Animator anim;
    public Rigidbody2D playerRigidbody;
    public int health = 20; //testing only
    public float jumpForce;
    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundlayer;
    public GameObject Boss1;
    //public GameObject telePos;


    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        //DeadorHurt();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //checks if the player is on the ground to avoid double jump
            if (isGrounded)
            {
                Jump();
            }

        }

    }

    void FixedUpdate()
    {
        //checks if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);
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

        if (Input.GetKey(KeyCode.D))
        {
            playerPosition.x = playerPosition.x + walkingSpeed;
            this.transform.position = playerPosition;
            anim.SetTrigger("isWalking");

            if (facingRight == false)
            {
                Flip();
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
            }
        }
        else if (Input.GetKey(KeyCode.E))
        {
            anim.SetTrigger("isTeleportIn");
            StartCoroutine(Teleport());
            //anim.SetTrigger("isTeleportOut");
            //Teleporter();
        }
      
        else
        {
            anim.SetTrigger("isIdle");
            
        }

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

    void Teleporter()
    {
        int positionX = Random.Range(-9, 1);
        Vector3 temp = new Vector3(positionX, Boss1.transform.position.y, Boss1.transform.position.z);
        //StartCoroutine(Teleport());
        Boss1.transform.position = temp;
        anim.SetTrigger("isTeleportOut");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 playerPosition = this.transform.position;
        if (collision.gameObject.tag == "HitPoint")
        {            
            if (facingRight == true)
            {
                playerRigidbody.velocity = new Vector2(jumpForce, 0);
                //playerRigidbody.velocity = Vector2.left * jumpForce;
                //playerPosition.x = playerPosition.x - 10f;
            }
            else
            {
                playerRigidbody.velocity = new Vector2(jumpForce, 0);
                //playerRigidbody.velocity = Vector2.right * jumpForce;
                //playerPosition.x = playerPosition.x + 10f;
            }
            anim.SetTrigger("isDamaged");
            StartCoroutine(Blink());
        }
    }

    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

    IEnumerator Teleport()
    {
        //int positionX = Random.Range(-9, 1);
        //Vector3 temp = new Vector3(positionX, Boss1.transform.position.y, Boss1.transform.position.z);
        //anim.SetTrigger("isTeleportIn");
        //anim.SetTrigger("isTeleportIn");
        yield return new WaitForSeconds(0.5f);
        Teleporter();
        //Boss1.transform.position = temp;
        //anim.SetTrigger("isTeleportOut");

    }

    
}
