using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeShooter : MonoBehaviour
{
    public Rigidbody2D spike;
    public Rigidbody2D spikeReverse;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpikeShoot", 1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpikeShoot()
    {
        if (this.transform.localScale.x >= 1)
        {
            Rigidbody2D latestIceBall = Instantiate(spikeReverse, this.transform.position, Quaternion.identity);

            latestIceBall.AddForce(new Vector2(500, 0) * speed);
        }
        else if (this.transform.localScale.x <= -1)
        {
            Rigidbody2D latestIceBall = Instantiate(spike, this.transform.position, Quaternion.identity);

            latestIceBall.AddForce(new Vector2(-500, 0) * speed);
        }
    }
}
