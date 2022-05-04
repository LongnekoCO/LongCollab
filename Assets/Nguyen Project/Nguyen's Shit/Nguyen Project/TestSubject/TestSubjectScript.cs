using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSubjectScript : MonoBehaviour
{
    public float health = 300;
    public bool enterGas = true;
    public ShrinkingArrowEffect otherScript;
    int temp;
    Coroutine lol; 
    
    // Start is called before the first frame update
    void Start()
    {
        otherScript = this.GetComponent<ShrinkingArrowEffect>();
        temp = otherScript.patrolSpeed; 
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Die();
        }

        //CheckGas();
    }

    public void TakeDamage(float dam)
    {
        health -= dam; 
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Arrow")
        {
            TakeDamage(10);
        }
        
    }

    void OnParticleCollision(GameObject other)
    {
        //StartCoroutine(DamageOverTime());
        if(enterGas == true)
        {
            StartCoroutine(SpeedDown());
            StartCoroutine(Gas());
            health -= 10;
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
   


}
