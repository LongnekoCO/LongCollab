using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballHit : MonoBehaviour
{
    private PlayerMovementScript playerScript; //a reference to player script
    public int damage; //a damage deal to the target
    public GameObject praticleHit;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovementScript>(); //access the player script
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerScript.TakeDamage(damage);
            Instantiate(praticleHit, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }
        else if (collision.gameObject.tag == "Wall")
        {
            Instantiate(praticleHit, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
