using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungLaser : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private PlayerMovementScript player;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<PlayerMovementScript>();
        Destroy(this.gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.TakeDamage(20);
        }
    }
}
