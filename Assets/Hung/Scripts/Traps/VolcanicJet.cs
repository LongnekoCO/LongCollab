using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanicJet : MonoBehaviour
{
    public GameObject lava;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LavaShoot", 1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LavaShoot()
    {
        GameObject lava1 = Instantiate(lava, this.transform.position, Quaternion.identity);
        Destroy(lava1, 3f);
    }
}
