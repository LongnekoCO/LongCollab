using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingExplosiveMissile : MonoBehaviour
{
    public GameObject[] targets;
    private Rigidbody2D rb;
    public float rotateSpeed = 200f;
    public float speed = 2f;
    public int Timer;

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
        StartCoroutine(SelfDestruct());

        //testSubject = GameObject.Find("TestSubject");
        //test = (TestSubjectScript)testSubject.GetComponent(typeof(TestSubjectScript));
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        targets = GameObject.FindGameObjectsWithTag("Enemy");


        foreach(var target in targets)
        {
            if (target != null)
            {
                Vector2 direction = (Vector2)target.transform.position - rb.position;

                direction.Normalize();

                float rotateAmount = Vector3.Cross(direction, transform.up).z;

                rb.angularVelocity = -rotateAmount * rotateSpeed;

                rb.velocity = transform.up * speed;
            }

            else if (target == null)
            {
                Debug.Log("None");
                Explode();
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Explode();
        }
        else
            Explode();
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(Timer);
        Destroy(gameObject);
    }

    void Explode()
    {

        var hitColliders = Physics2D.OverlapCircleAll(transform.position, fieldofImpact);

        foreach (var hitCollider in hitColliders)
        {
            var enemy = hitCollider.GetComponent<EnemyHealth>();


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
