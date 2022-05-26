using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("Open");
            
            StartCoroutine(OpenDoorRoutine());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("Close");
            
            StartCoroutine(CloseDoorRoutine());
        }
    }

    private IEnumerator OpenDoorRoutine()
    {
        yield return new WaitForSeconds(1f);
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    private IEnumerator CloseDoorRoutine()
    {
        yield return new WaitForSeconds(1f);
        this.GetComponent<BoxCollider2D>().enabled = true;
    }
}
