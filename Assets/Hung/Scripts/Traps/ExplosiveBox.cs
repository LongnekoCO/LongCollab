using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBox : MonoBehaviour
{
    private PlayerMovementScript player;
    public GameObject praticleHit;

    // Start is called before the first frame update
    void Start()
    {
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
            player.TakeDamage(40);
            Destroy(this.gameObject);
            Instantiate(praticleHit, this.transform.position, Quaternion.identity);
        }
    }
}
