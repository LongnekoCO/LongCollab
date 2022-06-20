using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlwindShooter : MonoBehaviour
{
    public Rigidbody2D whirlwind;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void WhirlwindShoot()
    {
        Rigidbody2D latestWhirlwind = Instantiate(whirlwind, this.transform.position, Quaternion.identity);

        latestWhirlwind.AddForce(new Vector2(500, 0) * speed);
    }
}
