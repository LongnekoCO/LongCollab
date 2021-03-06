using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;

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

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        Debug.Log("Door Open:" + keyType);
        animator.SetTrigger("Open");
        StartCoroutine(OpenDoorRoutine());
        
        //this.gameObject.SetActive(false);
    }

    private IEnumerator OpenDoorRoutine()
    {
        yield return new WaitForSeconds(1f);
        this.GetComponent<BoxCollider2D>().enabled = false;
    }
}
