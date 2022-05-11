using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViagraPill : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
