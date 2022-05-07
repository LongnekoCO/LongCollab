using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungIceballHit : MonoBehaviour
{
    private HungPlayer playerScript; //a reference to player script
    public int damage; //a damage deal to the target
    public float timeFreeze; //time to freeze the moving of the target
    public GameObject praticleHit;

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
            Instantiate(praticleHit, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            StartCoroutine(TimeFreeze());
        }
        else if (collision.gameObject.tag == "Wall")
        {
            Instantiate(praticleHit, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    //Time frezze to make target is not moving
    //Called by OnTriggerEnter2D() when it hits the target
    IEnumerator TimeFreeze()
    {
        playerScript.isMoving = false;
        yield return new WaitForSeconds(timeFreeze);
        playerScript.isMoving = true;
    }
}
