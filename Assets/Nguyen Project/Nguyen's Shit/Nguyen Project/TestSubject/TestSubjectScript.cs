using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSubjectScript : MonoBehaviour
{
   // public float health = 300;
    public bool enterGas = true;
    public ShrinkingArrowEffect otherScript;
    public EnemyHealth otherScript1; 
    int temp;
    Coroutine lol; 
    
    // Start is called before the first frame update
    void Start()
    {
        otherScript = this.GetComponent<ShrinkingArrowEffect>();
        otherScript1 = this.GetComponent<EnemyHealth>();
        temp = otherScript.patrolSpeed; 
    }

    // Update is called once per frame
    void Update()
    {
        

        //CheckGas();
    }

   

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Arrow")
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
        
    }

    void OnParticleCollision(GameObject other)
    {
        //StartCoroutine(DamageOverTime());
        if(enterGas == true)
        {
            StartCoroutine(SpeedDown());
            StartCoroutine(Gas());
            otherScript1.health -= 10;
        }
        
        
        //Debug.Log("Enter Gas");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ice")
        {
            StartCoroutine(IceAffect());
        }
    }

    

    IEnumerator Gas()
    {
        enterGas = false;        
        yield return new WaitForSecondsRealtime(1f);
        enterGas = true;
    }

    IEnumerator SpeedDown()
    {
        otherScript.patrolSpeed = otherScript.patrolSpeed - (otherScript.patrolSpeed / 2);
        yield return new WaitForSecondsRealtime(3f);
        otherScript.patrolSpeed = otherScript.patrolSpeed * 2;
    }
    
    IEnumerator IceAffect()
    {
        otherScript.mustPatrol = false;
        yield return new WaitForSecondsRealtime(2f);
        otherScript.mustPatrol = true;
    }
   
    IEnumerator AttackRockEffect()
    {
        otherScript.mustPatrol = false;
        otherScript1.TakeDamage(20);
        yield return new WaitForSeconds(0.2f);
        otherScript.mustPatrol = true;
    }

}
