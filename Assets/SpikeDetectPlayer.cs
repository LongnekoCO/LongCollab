using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDetectPlayer : MonoBehaviour
{
    private MetalSpikeTrap spikeTrapScript; 

    // Start is called before the first frame update
    void Start()
    {
        GameObject trap = this.transform.parent.gameObject;

        spikeTrapScript = trap.GetComponent<MetalSpikeTrap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            spikeTrapScript.inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spikeTrapScript.inRange = false;
        }
    }

}