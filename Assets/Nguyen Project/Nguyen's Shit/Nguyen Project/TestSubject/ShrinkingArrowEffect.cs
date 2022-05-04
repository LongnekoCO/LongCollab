using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingArrowEffect : MonoBehaviour
{
    public bool mustPatrol;

    public Rigidbody2D rb;

    public int patrolSpeed;
    public bool mustTurn;
    public bool facingRight = true;
    

    public Transform groundCheckPos;
    public LayerMask groundLayer;

    //Vector3 scaleChange; 
    Vector3 temp; 

    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
       // temp = this.transform.localScale;
        //scaleChange = new Vector3(this.transform.localScale.x/2, this.transform.localScale.y / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(mustPatrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if(mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if(mustTurn)
        {
            Flip();
        }
        rb.velocity = new Vector2(patrolSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        patrolSpeed *= -1;
        mustPatrol = true;
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "ShrinkingArrow")
        {
            StartCoroutine(Shrink());
        }
    }

    IEnumerator Shrink()
    {
        
        this.transform.localScale = new Vector3(this.transform.localScale.x / 2, this.transform.localScale.y/2, this.transform.localScale.z/2);
        //patrolSpeed = patrolSpeed - (patrolSpeed/2);
        yield return new WaitForSeconds(5f);
        this.transform.localScale = new Vector3(this.transform.localScale.x*2, this.transform.localScale.y*2, this.transform.localScale.z*2);
        
        //patrolSpeed = patrolSpeed * 2;
    }
}
