using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDirection : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        rb.AddForce(new Vector2 (100f, 0f) * Time.deltaTime);
    }
}
