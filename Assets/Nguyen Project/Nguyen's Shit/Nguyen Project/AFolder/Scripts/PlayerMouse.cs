using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : MonoBehaviour
{
    float walkingSpeed = 0.015f;
    private bool facingRight = true;
    Animator anim;
    public Rigidbody2D playerRigidbody;
    public int health = 20; //testing only
    public float jumpForce;
    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundlayer;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        DeadorHurt();

        //checks if the player is on the ground to avoid double jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
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

    //Jump Function
    //Called in Update
    void Jump()
    {
        playerRigidbody.velocity = Vector2.up * jumpForce;
    }



    //Player Movement 
    //Called in Update
    void Movement()
    {
        Vector3 playerPosition = this.transform.position;
        playerPosition.z = 1;

        if (Input.GetKey(KeyCode.D))
        {
            playerPosition.x = playerPosition.x + walkingSpeed;
            this.transform.position = playerPosition;
            anim.SetTrigger("isWalk");

            if (facingRight == false)
            {
                Flip();
            }
        }

        else if (Input.GetKey(KeyCode.A))
        {
            playerPosition.x = playerPosition.x - walkingSpeed;
            this.transform.position = playerPosition;
            anim.SetTrigger("isWalk");

            if (facingRight == true)
            {
                Flip();
            }
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

    //for testing animation
    void DeadorHurt()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("isHurt");
            health -= 10;

            if (health <= 0)
            {
                anim.SetTrigger("isDead");
                StartCoroutine(Dead());
            }
            
        }      
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
        GetComponent<PlayerMouse>().enabled = false;

    }
}
