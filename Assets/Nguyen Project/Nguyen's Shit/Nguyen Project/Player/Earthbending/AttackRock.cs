using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRock : MonoBehaviour
{
    Animator anim;
    private PlayerMovementScript playerScript;
    public Rigidbody2D rockRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        playerScript = GameObject.Find("Dog").GetComponent<PlayerMovementScript>();
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //rockRigidbody.velocity = Vector3.zero;
            //rockRigidbody.angularVelocity = Vector3.zero;
            anim.SetTrigger("destroy");
            StartCoroutine(AnotherWait());
           // rockRigidbody.AddForce(transform.right * 0f, ForceMode2D.Impulse);
        }
       
        
    }

    IEnumerator AnotherWait()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
