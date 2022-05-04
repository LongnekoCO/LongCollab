using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantExplodingArrow : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit;
    public float damage = 50.0f;

    public float fieldofImpact;
    public float force;
    public LayerMask layerToHit;

    public GameObject explosionEffect;

    //public GameObject testSubject;
    //TestSubjectScript test;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //testSubject = GameObject.Find("TestSubject");
        //test = (TestSubjectScript)testSubject.GetComponent(typeof(TestSubjectScript));
    }

    // Update is called once per frame
    void Update()
    {
        if (hasHit == false)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        Explode();

    }

    void Explode()
    {

        //Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, layerToHit);

        //foreach (Collider2D obj in objects)
        //{           
        //    Vector2 direction = obj.transform.position - transform.position;           

        //    obj.GetComponent<Rigidbody2D>().AddForce(direction * force);

        //    if (obj.gameObject.tag == "Enemy")
        //    {
        //        var enemy = obj.GetComponent<TestSubjectScript>();

        //        enemy.TakeDamage(50);
        //    }
        //}

        var hitColliders = Physics2D.OverlapCircleAll(transform.position, fieldofImpact); 

        foreach(var hitCollider in hitColliders)
        {
            var enemy = hitCollider.GetComponent<TestSubjectScript>();
                       
            
            if (enemy)
            {
                var closestPoint = hitCollider.ClosestPoint(transform.position);
                var distance = Vector3.Distance(closestPoint, transform.position);

                var damagePercent = Mathf.InverseLerp(fieldofImpact, 0, distance);

                Vector2 direction = enemy.transform.position - this.transform.position;

                enemy.TakeDamage(damagePercent * damage);
                enemy.GetComponent<Rigidbody2D>().AddForce(direction * force);
            }
        }

        GameObject ExplosionEffectIns = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(ExplosionEffectIns, 5);
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldofImpact);
    }
}
