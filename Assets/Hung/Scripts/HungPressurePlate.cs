using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungPressurePlate : MonoBehaviour
{
    public GameObject testObject;
    public GameObject explosion;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(testObject);
            Instantiate(explosion, testObject.transform.position, Quaternion.identity);
        }
    }
}
