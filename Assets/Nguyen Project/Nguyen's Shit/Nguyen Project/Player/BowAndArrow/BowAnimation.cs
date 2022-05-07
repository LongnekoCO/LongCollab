using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAnimation : MonoBehaviour
{
    Animator anim;
    public bool canAnim; 

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        canAnim = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if(canAnim == true)
        {
            StretchAndShoot();
        }        
    }

    void StretchAndShoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("isStretch");
        }
        else if(Input.GetMouseButtonUp(0))
        {
            anim.SetTrigger("isShoot");
        }
        else
        {
            anim.SetTrigger("isIdle");
        }
    }
}
