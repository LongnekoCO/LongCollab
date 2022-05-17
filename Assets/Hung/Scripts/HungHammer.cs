using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungHammer : MonoBehaviour
{
    private PlayerMovementScript player;
    
    // Start is called before the first frame update
    void Start()
    {
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
            player.TakeDamage(30);
        }
    }
}
