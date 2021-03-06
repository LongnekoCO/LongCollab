using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBallShooter : MonoBehaviour
{
    public Rigidbody2D iceBall;
    public Rigidbody2D iceBallReverse;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IceBallShoot", 1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IceBallShoot()
    {
        if (this.transform.localScale.x >= 1)
        {
            Rigidbody2D latestIceBall = Instantiate(iceBall, this.transform.position, Quaternion.identity);

            latestIceBall.AddForce(new Vector2(500, 0) * speed);
        }
        else if (this.transform.localScale.x <= -1)
        {
            Rigidbody2D latestIceBall = Instantiate(iceBallReverse, this.transform.position, Quaternion.identity);

            latestIceBall.AddForce(new Vector2(-500, 0) * speed);
        }
    }
}
