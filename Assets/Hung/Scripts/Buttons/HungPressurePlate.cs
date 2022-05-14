using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungPressurePlate : MonoBehaviour
{
    public GameObject testObject;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("Pressed");
            Destroy(testObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("Unpressed");
        }
    }
}
