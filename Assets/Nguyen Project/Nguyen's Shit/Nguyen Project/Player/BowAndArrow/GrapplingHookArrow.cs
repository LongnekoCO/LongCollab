using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHookArrow : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit;
    public Bow bowScript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bowScript = GameObject.FindGameObjectWithTag("Bow").GetComponent<Bow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasHit == false)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (hasHit == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                bowScript.ReleaseGrappling();
                Destroy(gameObject);
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        bowScript.TargetHitGrappling(this.gameObject);
        hasHit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        //Destroy(gameObject);
    }
}
