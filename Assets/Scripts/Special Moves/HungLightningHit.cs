using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungLightningHit : MonoBehaviour
{
    private HungPlayer playerScript; //a reference to player script
    public int damage; //a damage deal to the target

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<HungPlayer>(); //access the player script
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
            Destroy(this.gameObject);
        }
    }
}
