using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBeeHive : MonoBehaviour
{

    public int HP;
    public int CurrentHP;
    public GameObject Bee;
    public Transform[] SpawnPoint;
    public int CurrentBee;
    public int MaxBee;
    public int BeeSpawned;
    public int currentSpawn;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = HP;
        InvokeRepeating("BeeSpawner", 5, MaxBee);
    }

    // Update is called once per frame
    void Update()
    {

        

        if(CurrentHP==0)
        {
            
            Instantiate(Bee, SpawnPoint[currentSpawn].transform.position,Quaternion.identity);
            Instantiate(Bee, SpawnPoint[currentSpawn].transform.position, Quaternion.identity);
            Instantiate(Bee, SpawnPoint[currentSpawn].transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            CurrentHP -= HP;
        }
        
    }

    public void BeeSpawner()
    {        
        if(CurrentBee<MaxBee)
        {
            Instantiate(Bee, SpawnPoint[Random.Range(0, 3)].transform.position, Quaternion.identity);
            BeeSpawned += 1;
            
        }


    }
   
}
