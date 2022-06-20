using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBallShooter : MonoBehaviour
{
    public Rigidbody2D iceBall;
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
        Rigidbody2D latestIceball = Instantiate(iceBall, this.transform.position, Quaternion.identity);

        latestIceball.AddForce(new Vector2(500, 0) * speed);
    }
}
