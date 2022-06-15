using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILaserTest : MonoBehaviour
{
    //public Camera cam;
    public LineRenderer lineRenderer;
    public Transform firePoint;
    private Quaternion rotation;
    public LayerMask mask;

    public GameObject startEf;
    public GameObject endEf;
    private List<ParticleSystem> particles = new List<ParticleSystem>();

    public float thrust;
    public float knockTime;

    public GameObject player;
    public Transform playerTarget;
    public bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerTarget = player.transform.Find("Target");
        
        FillLists();
        //DisableLaser();
    

    }

    // Update is called once per frame
    void Update()
    {
        if(canShoot == true)
        {
            //UpdateLaser();
            //UpdateLaser();
            ActiveLaser();
            UpdateLaser();
            StartCoroutine(LaserTime());
        }

        else
        {
            DisableLaser();
        }

    }

    void ActiveLaser()
    {
        lineRenderer.enabled = true;

        for (int i = 0; i < particles.Count; i++)
        {
            particles[i].Play();
            //Debug.Log("particles");
        }
            
    }
  
   void UpdateLaser()
    {
        

        lineRenderer.SetPosition(0, (Vector2)firePoint.position);
        startEf.transform.position = (Vector2)firePoint.position;

        lineRenderer.SetPosition(1, (Vector2)playerTarget.position);

        Vector2 direction = (Vector2)playerTarget.position - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction.normalized, direction.magnitude, mask);


        if (hit)
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hit.point);
            //Debug.Log(hit.point);

            if (hit.collider.tag == "Player")
            {
                Rigidbody2D enemy = hit.collider.GetComponent<Rigidbody2D>();
                //Debug.Log(hit.collider.name);
                if (enemy != null)
                {
                    //Debug.Log(hit.collider.name);
                    //enemy.isDynamic = false;
                    Vector2 difference = enemy.transform.position - transform.position;
                    difference = difference.normalized * thrust;
                    enemy.AddForce(difference, ForceMode2D.Impulse);
                    StartCoroutine(KnockCo(enemy));
                }
                
            }
            
        }

        endEf.transform.position = new Vector3 (hit.point.x, hit.point.y, 0);
        //Debug.Log(endEf.transform.position);
    }

    IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
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

    IEnumerator LaserTime()
    {
        yield return new WaitForSeconds(2f);
        canShoot = false;
    }

    void FillLists()
    {
        for (int i = 0; i < startEf.transform.childCount; i++)
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
