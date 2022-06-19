using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueSpawner : MonoBehaviour
{
    public Rigidbody2D glueRb;
    public float timeStart;
    public float timeDelay;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GlueAttack", timeStart, timeDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GlueAttack()
    {
        Instantiate(glueRb, this.transform.position, Quaternion.identity);
    }
}
