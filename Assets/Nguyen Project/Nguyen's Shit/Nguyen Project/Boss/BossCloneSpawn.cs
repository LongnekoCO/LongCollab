using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCloneSpawn : MonoBehaviour
{
    GameObject cloneSpawnPoint;
    public GameObject clone;
    public bool canSpawn;
    public int numberOfClones;
    //private int numberOfMissiles;
   // public bool outOfMissiles = false;

    // Start is called before the first frame update
    
    void Awake()
    {
        cloneSpawnPoint = transform.Find("CloneSpawn").gameObject;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForClones();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "CloneSpawn")
        {
            if(canSpawn == true)
            {
                Spawn();
            }
        }
    }

    void Spawn()
    {
        
            Instantiate(clone, cloneSpawnPoint.transform.position, Quaternion.identity);
            numberOfClones++;

            canSpawn = false;

        
    }

    public void CheckForClones()
    {
        if (numberOfClones == 0)
        {
            canSpawn = true;
        }
    }
}
