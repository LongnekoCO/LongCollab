using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTest : MonoBehaviour
{
    public Camera cam;
    public LineRenderer lineRenderer;
    public Transform firePoint;
    private Quaternion rotation;
    public LayerMask mask;

    public GameObject startEf;
    public GameObject endEf;
    private List<ParticleSystem> particles = new List<ParticleSystem>();

    public float thrust;
    public float knockTime; 

    // Start is called before the first frame update
    void Start()
    {
        FillLists();
        DisableLaser();
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Fire1"))
        {
            EnableLaser();
        }

       if(Input.GetButton("Fire1"))
        {
            UpdateLaser();
        }

       if(Input.GetButtonUp("Fire1"))
        {
            DisableLaser();
        }
    }

    void EnableLaser()
    {
        lineRenderer.enabled = true;

        for (int i = 0; i < particles.Count; i++)
            particles[i].Play();
    }

    void UpdateLaser()
    {
        var mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        lineRenderer.SetPosition(0, (Vector2)firePoint.position);
        startEf.transform.position = (Vector2)firePoint.position;

        lineRenderer.SetPosition(1, mousePos);

        Vector2 direction = mousePos - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction.normalized, direction.magnitude, mask);


        if(hit)
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hit.point);
            //Debug.Log(hit.point);

            if (hit.collider.tag == "Enemy")
            {
                Rigidbody2D enemy = hit.collider.GetComponent<Rigidbody2D>();
                if(enemy != null)
                {
                    //enemy.isDynamic = false;
                    Vector2 difference = enemy.transform.position - transform.position;
                    difference = difference.normalized * thrust;
                    enemy.AddForce(difference, ForceMode2D.Impulse);
                    StartCoroutine(KnockCo(enemy));
                }

            }
            
        }

        endEf.transform.position = lineRenderer.GetPosition(1);
        Debug.Log(endEf.transform.position);
    }

    IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if(enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            //enemy.isKinematic = true;
        }
    }

    void DisableLaser()
    {
        lineRenderer.enabled = false;
        for (int i = 0; i < particles.Count; i++)
            particles[i].Stop();
    }

    void FillLists()
    {
        for(int i = 0; i < startEf.transform.childCount; i++)
        {
            var ps = startEf.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null)
                particles.Add(ps);
        }

        for (int i = 0; i < endEf.transform.childCount; i++)
        {
            var ps = endEf.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null)
                particles.Add(ps);
        }
    }
}

