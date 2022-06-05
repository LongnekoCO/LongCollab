using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLaser : MonoBehaviour
{
    public Rigidbody2D laser;
    public float speed;
    private PlayerMovementScript player;
    
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("LaserShoot", 1f, 5f);

        player = GameObject.Find("Player").GetComponent<PlayerMovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.TakeDamage(50);
        }
    }

    void LaserShoot()
    {
        Rigidbody2D latestLaser = Instantiate(laser, this.transform.position, Quaternion.identity);

        latestLaser.AddForce(new Vector2(500, 0) * speed);
    }
}
