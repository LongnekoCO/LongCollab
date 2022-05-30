using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalSpikeTrap : MonoBehaviour
{
    Animator anim;
    public bool inRange = false;
    Collider2D colliderr;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        colliderr = this.GetComponent<Collider2D>();
        anim.SetTrigger("isIdle");
        colliderr.enabled = !colliderr.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange == true)
        {
            StartCoroutine(SpikeUp());
        }
    }

    void PlayAnimation()
    {
        
    }

    IEnumerator SpikeUp()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetTrigger("isSpikeUp");
        colliderr.enabled = colliderr.enabled;
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpikeDown());
    }

    IEnumerator SpikeDown()
    {        
        anim.SetTrigger("isSpikeDown");
        colliderr.enabled = !colliderr.enabled;
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("isIdle");
    }

}
