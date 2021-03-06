using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject testObject;
    private Animator animator;
    private Animator testObjectAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        testObjectAnim = testObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("Pressed");
            OpenDoor();
        }
        
        else if (collision.gameObject.tag == "MovableObject")
        {
            animator.SetTrigger("Pressed");
            OpenDoor();
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("Unpressed");
            CloseDoor();
        }
        
        else if (collision.gameObject.tag == "MovableObject")
        {
            animator.SetTrigger("Unpressed");
            CloseDoor();
        }
    }

    public void OpenDoor()
    {
        testObjectAnim.SetTrigger("Open");
        StartCoroutine(OpenDoorRoutine());
    }
    
    public void CloseDoor()
    {
        testObjectAnim.SetTrigger("Close");
        StartCoroutine(CloseDoorRoutine());
    }

    private IEnumerator OpenDoorRoutine()
    {
        yield return new WaitForSeconds(1f);
        testObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private IEnumerator CloseDoorRoutine()
    {
        yield return new WaitForSeconds(1f);
        testObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
