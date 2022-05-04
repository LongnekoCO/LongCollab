using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitateBox : MonoBehaviour
{
    //public bool startTimer = false;
    //public float timer = 5f;
    private BossLevitatePower bossScript; 
    
    // Start is called before the first frame update
    void Start()
    {
        bossScript = this.GetComponentInParent<BossLevitatePower>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bossScript.deactivate = true;
        }
    }

}
