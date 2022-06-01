using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetractableMetalSpikeScript : MonoBehaviour
{
    
    Animator anim;
    Collider2D spikeCol;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        spikeCol = this.GetComponent<Collider2D>();
        anim.SetBool("isSpikeDown", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpikeGoingUp()
    {
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.2f);
        anim.SetBool("isSpikeUp", true);
        spikeCol.enabled = true; 
    }

    public void SpikeGoingDown()
    {
        anim.SetBool("isSpikeUp", false);
        anim.SetBool("isSpikeDown", true);
        StartCoroutine(Meh());
        
        
    }

    IEnumerator Meh()
    {
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("isSpikeDown", false);
        yield return new WaitForSeconds(0.1f);
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 0.2f);
        spikeCol.enabled = false;
    }
}
