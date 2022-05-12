using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungKey : MonoBehaviour
{
    private PlayerMovementScript player;
    public GameObject door;

    [SerializeField] private KeyType keyType;

    public enum KeyType
    {
        Red,
        Yellow,
        Green,
        Blue
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Dog").GetComponent<PlayerMovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(door);
        }
    }
}
