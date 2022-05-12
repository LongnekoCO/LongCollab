using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungSpike : MonoBehaviour
{
    //private Collider2D collider;
    private PlayerMovementScript player;

    // Start is called before the first frame update
    void Start()
    {
        //collider = this.GetComponent<Collider2D>();
        player = GameObject.Find("Dog").GetComponent<PlayerMovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InvokeRepeating("DamageLooping", 1f, 3f);
        }
    }

    void DamageLooping()
    {
        player.TakeDamage(10);
    }
}
