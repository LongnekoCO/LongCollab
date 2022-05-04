using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissileFiring : MonoBehaviour
{

    GameObject firingPoint;
    public GameObject missile;
    public bool canShoot;
    private int numberOfMissiles;
    public bool outOfMissiles = false;
    //GameObject boss; 
    
    void Awake()
    {
        firingPoint = transform.Find("MissileFiringPoint").gameObject;
        
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if(canShoot == true)
        {
            Instantiate(missile, firingPoint.transform.position, Quaternion.identity);
            numberOfMissiles++;

            canShoot = false;
        }
    }

    public void CheckForLastMissiles()
    {
        numberOfMissiles--; 
        if(numberOfMissiles == 0)
        {
            outOfMissiles = true;
            canShoot = true;
        }
    }
}
