using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallShooter : MonoBehaviour
{
    public Rigidbody2D fireBall;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireBallShoot", 1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireBallShoot()
    {
        Rigidbody2D latestFireball = Instantiate(fireBall, this.transform.position, Quaternion.identity);

        latestFireball.AddForce(new Vector2(500, 0) * speed);
    }
}
