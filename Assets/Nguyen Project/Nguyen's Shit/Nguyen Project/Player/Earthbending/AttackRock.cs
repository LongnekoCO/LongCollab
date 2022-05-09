using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRock : MonoBehaviour
{
    Animator anim;
    private PlayerMovementScript playerScript;
    public Rigidbody2D rockRigidbody;
    public float thrust;
    public GameObject player; 


    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        playerScript = GameObject.Find("Dog").GetComponent<PlayerMovementScript>();
        player = GameObject.Find("Dog");
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerScript.facingRight == true)
        {
            StartCoroutine(Wait());
            
        }
        else if(playerScript.facingRight == false)
        {
            StartCoroutine(Wait2());
            //rockRigidbody.AddForce(transform.right * -4f, ForceMode2D.Impulse);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.2f);
        rockRigidbody.AddForce(transform.right * 6f, ForceMode2D.Impulse);
    }

    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(1.2f);
        rockRigidbody.AddForce(transform.right * -6f, ForceMode2D.Impulse);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "ArrowBox")
        {
            Rigidbody2D meow = collision.gameObject.GetComponent<Rigidbody2D>();
            //meow.isKinematic = false;
            Vector2 difference = meow.transform.position - player.transform.position;
            difference = difference.normalized * thrust;
            meow.AddForce(difference, ForceMode2D.Impulse);

            anim.SetTrigger("destroy");
            StartCoroutine(AnotherWait());
           


        }

        else
        {
            anim.SetTrigger("destroy");
            StartCoroutine(AnotherWait());
        }
       
        
    }

    IEnumerator AnotherWait()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

   
}
