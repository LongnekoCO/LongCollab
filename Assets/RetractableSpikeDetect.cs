using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetractableSpikeDetect : MonoBehaviour
{
    RetractableMetalSpikeScript spikeScript;
    GameObject spike; 

    // Start is called before the first frame update
    void Start()
    {
        spike = this.transform.parent.gameObject;
        spikeScript = spike.GetComponent<RetractableMetalSpikeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            spikeScript.SpikeGoingUp();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spikeScript.SpikeGoingDown();
        }
    }

}
