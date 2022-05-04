using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAnimation : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StretchAndShoot();
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
