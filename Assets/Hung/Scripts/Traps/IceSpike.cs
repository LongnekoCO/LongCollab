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
        Physics2D.queriesStartInColliders = false;

        if (isFalling == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, distance);

            Debug.DrawRay(this.transform.position, Vector2.down * distance, Color.red);

            if (hit.transform != null)
            {
                if (hit.transform.tag == "Player")
                {
                    Invoke("IceSpikeFalling", 0.5f);
                }
            }
        }
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

    void IceSpikeFalling()
    {
        rigidbody2d.gravityScale = 3;
        isFalling = true;
    }
}
