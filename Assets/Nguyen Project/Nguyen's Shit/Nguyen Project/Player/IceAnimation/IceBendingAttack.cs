using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBendingAttack : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        StartCoroutine(IceShattered());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IceShattered()
    {
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("IceShatter");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
