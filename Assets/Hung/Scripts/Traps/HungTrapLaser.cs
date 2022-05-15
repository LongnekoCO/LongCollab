using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungTrapLaser : MonoBehaviour
{
    public Rigidbody2D laser;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaserShoot", 1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LaserShoot()
    {
        Rigidbody2D latestLaser = Instantiate(laser, this.transform.position, Quaternion.identity);

        latestLaser.AddForce(new Vector2(500, 0) * speed);
    }
}
