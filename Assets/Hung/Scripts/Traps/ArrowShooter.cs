using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    public Rigidbody2D arrow;
    public float arrowSpeed;
    
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
        Rigidbody2D latestArrow = Instantiate(arrow, this.transform.position, Quaternion.identity);

        latestArrow.AddForce(new Vector2(500, 0) * arrowSpeed);
    }
}
