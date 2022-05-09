using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungBlockDestroy : MonoBehaviour
{
    private Collider2D collider;
    
    // Start is called before the first frame update
    void Start()
    {
        collider = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
