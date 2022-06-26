using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //public ShrinkingArrowEffect otherScript;
    public EnemyHealth otherScript1;
    public bool enterGas;
    // Start is called before the first frame update
    void Start()
    {
        otherScript1 = this.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            otherScript1.TakeDamage(10);
        }

        if (col.gameObject.tag == "AttackRock")
        {
            //this.GetComponent<Rigidbody2D>().isKinematic = false;
            //TakeDamage(20);
            StartCoroutine(AttackRockEffect());
            //this.GetComponent<Rigidbody2D>().isKinematic = true;
        }

        if (col.gameObject.tag == "CapShield")
        {
            Vector2 direction = col.transform.position - this.transform.position;
            this.GetComponent<Rigidbody2D>().AddForce(direction * 10000f);
            otherScript1.TakeDamage(30);
        }
        if (col.gameObject.tag == "Thor'sHammer")
        {
            Vector2 direction = col.transform.position - this.transform.position;
            this.GetComponent<Rigidbody2D>().AddForce(direction * 10000f);
            otherScript1.TakeDamage(40);
        }

    }
    void OnParticleCollision(GameObject other)
    {
        //StartCoroutine(DamageOverTime());
        if (enterGas == true)
        {
            //StartCoroutine(SpeedDown());
            StartCoroutine(Gas());
            otherScript1.health -= 10;
        }


        //Debug.Log("Enter Gas");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ice")
        {
            otherScript1.TakeDamage(40);
        }

        else if (col.gameObject.tag == "Lightning")
        {
            otherScript1.TakeDamage(50);
        }
    }

    IEnumerator Gas()
    {
        enterGas = false;
        yield return new WaitForSecondsRealtime(1f);
        enterGas = true;
    }
    

    IEnumerator AttackRockEffect()
    {
        //otherScript.mustPatrol = false;
        otherScript1.TakeDamage(20);
        yield return new WaitForSeconds(0.2f);
        //otherScript.mustPatrol = true;
    }
}
