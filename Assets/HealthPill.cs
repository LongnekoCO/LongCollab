using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPill : MonoBehaviour
{
    private PlayerMovementScript healthScript;
    public float speed = 5f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        healthScript = FindObjectOfType<PlayerMovementScript>();
        StartCoroutine(SelfDestruct());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(healthScript.currentHealth < healthScript.health)
            {
                healthScript.GetHealth(30);
                Destroy(this.gameObject);
            }

            else
            {
                Destroy(this.gameObject);
            }
     
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
