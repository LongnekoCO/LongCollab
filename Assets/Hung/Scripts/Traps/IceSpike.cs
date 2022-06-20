using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpike : MonoBehaviour
{
    private PlayerMovementScript player;
    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rigidbody2d;
    public float distance;
    private bool isFalling = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
        boxCollider2D = this.GetComponent<BoxCollider2D>();
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
            player.TakeDamage(10);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
