using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlwind : MonoBehaviour
{
    private PlayerMovementScript playerScript; //a reference to player script
    public int damage; //a damage deal to the target
    public float timeToDestroy; //time to destroy this target
    public float timeLimited; //a time that enemy have more move speed in limited
    public GameObject praticleHit;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMovementScript>(); //access the player script
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
            StartCoroutine(PlayerMoveSpeedCoroutine());
            Instantiate(praticleHit, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject, timeToDestroy);
        }
    }

    //Called in OnTriggerEnter2D()
    IEnumerator PlayerMoveSpeedCoroutine()
    {
        playerScript.walkingSpeed -= 10;
        yield return new WaitForSeconds(timeLimited);
        playerScript.walkingSpeed += 10;
    }
}
