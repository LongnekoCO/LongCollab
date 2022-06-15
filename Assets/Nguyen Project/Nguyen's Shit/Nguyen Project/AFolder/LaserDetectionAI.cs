using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDetectionAI : MonoBehaviour
{
    public GameObject AI;
    public AILaserTest laserScript; 
    
    // Start is called before the first frame update
    void Start()
    {
        AI = this.transform.parent.gameObject;
        laserScript = AI.GetComponent<AILaserTest>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            laserScript.canShoot = true;
        }
    }

}
