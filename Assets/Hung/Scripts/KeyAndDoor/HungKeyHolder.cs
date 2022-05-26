using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungKeyHolder : MonoBehaviour
{
    private List<HungKey.KeyType> keyList;

    private void Awake()
    {
        keyList = new List<HungKey.KeyType>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HungKey key = collision.GetComponent<HungKey>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        HungLockedDoor lockedDoor = collision.GetComponent<HungLockedDoor>();
        if (lockedDoor != null)
        {
            if (ContainsKey(lockedDoor.GetKeyType()))
            {
                //Currently holding Key to open this door
                RemoveKey(lockedDoor.GetKeyType());
                lockedDoor.OpenDoor();
            }
        }
    }

    public void AddKey(HungKey.KeyType keyType)
    {
        Debug.Log("Added Key: " + keyType);
        keyList.Add(keyType);
    }

    public void RemoveKey(HungKey.KeyType keyType)
    {
        keyList.Remove(keyType);
    }

    public bool ContainsKey(HungKey.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }
}
