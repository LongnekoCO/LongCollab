using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    public Rigidbody2D arrow;
    public float speed;
    private bool facingRight;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ArrowShoot", 1f, 5f);
        facingRight = true;
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

            ArrowFlip();
        }
        else if (this.transform.localScale.x <= -1)
        {
            Rigidbody2D latestArrow = Instantiate(arrow, this.transform.position, Quaternion.identity);

            latestArrow.AddForce(new Vector2(-500, 0) * speed);

            ArrowFlip();
        }
    }

    void ArrowFlip()
    {
        Vector2 ballFlip = arrow.transform.localScale;
        ballFlip.x = ballFlip.x * -1;
        arrow.transform.localScale = ballFlip;
        facingRight = !facingRight;
    }
}
