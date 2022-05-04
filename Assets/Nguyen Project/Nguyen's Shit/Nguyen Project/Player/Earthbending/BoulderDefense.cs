 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderDefense : MonoBehaviour
{
    Animator anim;
    public bool stop; 

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        StartCoroutine(BoulderFall());
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    IEnumerator BoulderFall()
    {
        //anim.SetTrigger("fall");
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("fall");
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
        //stop = false;
    }
}
