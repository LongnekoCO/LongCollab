using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongSpawnPoint : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Dog").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.transform.position = spawnPoint.transform.position;
        }
    }
}
