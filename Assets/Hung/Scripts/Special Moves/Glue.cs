using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glue : MonoBehaviour
{
    private PlayerMovementScript player;
    public float timeStop;
    private Rigidbody2D rb;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovementScript>();
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //rb.bodyType = RigidbodyType2D.Kinematic;
            //anim.SetTrigger("Ground");
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            player.TakeDamage(10);
            Destroy(this.gameObject);
            //StartCoroutine(StopMoving());
        }
    }

    IEnumerator StopMoving()
    {
        //player.isMoving = false;
        yield return new WaitForSeconds(timeStop);
        //player.isMoving = true;
    }
}
