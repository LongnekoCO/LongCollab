using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungButton : MonoBehaviour
{
    public GameObject testObject;

    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = testObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("key press");
            Destroy(this.gameObject);
            OpenDoor();
        }
        else if (collision.gameObject.tag == "MovableObject")
        {
            Debug.Log("key press");
            Destroy(this.gameObject);
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        animator.SetTrigger("Open");
        testObject.GetComponent<BoxCollider2D>().enabled = false; //test only
        //StartCoroutine(OpenDoorRoutine());
    }

    private IEnumerator OpenDoorRoutine()
    {
        yield return new WaitForSeconds(1f);
        testObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
