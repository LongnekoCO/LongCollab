using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungSpike : MonoBehaviour
{
    private Collider2D collider;
    private HungPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        collider = this.GetComponent<Collider2D>();
        player = GameObject.Find("Player").GetComponent<HungPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HungPlayer>().TakeDamage(10);
        }
    }
}
