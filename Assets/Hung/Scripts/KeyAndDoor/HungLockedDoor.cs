using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungLockedDoor : MonoBehaviour
{
    [SerializeField] private HungKey.KeyType keyType;

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

    public HungKey.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        Debug.Log("Door Open:" + keyType);
        animator.SetTrigger("Open");
        this.GetComponent<BoxCollider2D>().enabled = false;
        //this.gameObject.SetActive(false);
    }
}
