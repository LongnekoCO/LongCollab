using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    public Rigidbody2D arrow;
    public Rigidbody2D arrowReverse;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ArrowShoot", 1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ArrowShoot()
    {
        if (this.transform.localScale.x >= 1)
        {
            Rigidbody2D latestArrow = Instantiate(arrow, this.transform.position, Quaternion.identity);

            latestArrow.AddForce(new Vector2(500, 0) * speed);
        }
        else if (this.transform.localScale.x <= -1)
        {
            Rigidbody2D latestArrow = Instantiate(arrowReverse, this.transform.position, Quaternion.identity);

            latestArrow.AddForce(new Vector2(-500, 0) * speed);
        }
    }
}
