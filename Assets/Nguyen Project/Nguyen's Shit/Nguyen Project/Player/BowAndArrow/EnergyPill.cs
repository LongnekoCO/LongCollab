using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPill : MonoBehaviour
{

    private PlayerBowAndPowers energyScript;
    public float speed = 5f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        energyScript = FindObjectOfType<PlayerBowAndPowers>();
        StartCoroutine(SelfDestruct());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(energyScript.currentEnergy < energyScript.energy)
            {
                energyScript.RegainEnergy(30);
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
