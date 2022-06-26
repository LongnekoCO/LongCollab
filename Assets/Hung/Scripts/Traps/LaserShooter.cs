using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    public Rigidbody2D laser;
    public Rigidbody2D laserReverse;
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
        if (this.transform.localScale.x >= 1)
        {
            Rigidbody2D latestLaser = Instantiate(laser, this.transform.position, Quaternion.identity);

            latestLaser.AddForce(new Vector2(500, 0) * speed);
        }
        else if (this.transform.localScale.x <= -1)
        {
            Rigidbody2D latestLaser = Instantiate(laserReverse, this.transform.position, Quaternion.identity);

            latestLaser.AddForce(new Vector2(-500, 0) * speed);
        }
    }
}
