using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstArrow : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit;
    public GameObject homingExplosiveArrow;
    public Transform pos1, pos2;
    public GameObject explosionEffect;
    //public float launchForce;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasHit == false)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (Input.GetMouseButtonDown(1))
            {
                GameObject ExplosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(ExplosionEffectIns, 2);
                Destroy(gameObject);

                DuplicateArrow();
                DuplicateArrow2();

            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        Destroy(gameObject, 1);
    }

    void DuplicateArrow()
    {
        GameObject newArrow = Instantiate(homingExplosiveArrow, pos1.position, pos1.rotation);
        //newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        //transform.right * launchForce;
        //newArrow.GetComponent<Rigidbody2D>().velocity = transform.up * 1;
        //rb.velocity = new Vector3(0, 10, 0);
    }
    void DuplicateArrow2()
    {
        GameObject newArrow = Instantiate(homingExplosiveArrow, pos2.position, pos2.rotation);
        //newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }
}