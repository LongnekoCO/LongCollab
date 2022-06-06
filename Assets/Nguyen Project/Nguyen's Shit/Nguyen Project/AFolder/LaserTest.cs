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
            endEf.transform.position = lineRenderer.GetPosition(1);
            Debug.Log(hit.collider.name);
        }

        //endEf.transform.position = lineRenderer.GetPosition(1);
        //if(hit)
        //{
        //    lineRenderer.SetPosition(0, firePoint.position);
        //    lineRenderer.SetPosition(1, hit.point);
        //    Debug.Log("Hit" + hit);
        //}

        //else
        //{
        //    lineRenderer.SetPosition(0, firePoint.position);
        //    lineRenderer.SetPosition(1, mousePos);

        //}
       

    }

    void DisableLaser()
    {
        lineRenderer.enabled = false;
        for (int i = 0; i < particles.Count; i++)
            particles[i].Stop();
    }

    //void RotateToMouse()
    //{
    //    Vector2 direction = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //    rotation.eulerAngles = new Vector3(0, 0, angle);
    //    transform.rotation = rotation; 
    //}

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

