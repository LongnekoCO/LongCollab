using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungLockedDoor : MonoBehaviour
{
    [SerializeField] private HungKey.KeyType keyType;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        this.gameObject.SetActive(false);
    }
}
