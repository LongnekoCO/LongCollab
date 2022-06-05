using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    //private Collider2D collider;
    private PlayerMovementScript player;

    // Start is called before the first frame update
    void Start()
    {
        //collider = this.GetComponent<Collider2D>();
        player = GameObject.Find("Player").GetComponent<PlayerMovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.TakeDamage(20);
        }
    }
}
