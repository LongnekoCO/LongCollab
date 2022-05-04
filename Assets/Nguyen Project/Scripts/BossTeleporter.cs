using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTeleporter : MonoBehaviour
{
    private GameObject currentTeleporter;
    private Animator anim;
    private BossPatrol bossScipt;
    //public float timer = 5f;
    public Transform teleportPoint;
    //public GameObject Boss;
    public Transform target;
    public Collider2D bosss;

    // Start is called before the first frame update
    void Start()
    {
        bossScipt = this.GetComponent<BossPatrol>();
        anim = this.GetComponent<Animator>();
        //Teleport();
        //StartCoroutine(TeleportCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        //if (currentTeleporter != null)
        //{
        //this.transform.position = currentTeleporter.GetComponent<Waypoint>().TeleportTarget().position;
        //}
        
        /*
        if (this.transform.position.x == teleportPoint.position.x)
        {
            bossScipt.canMove = false;
            anim.SetTrigger("TeleportIn");
            StartCoroutine(TeleportCoroutine());
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "RealTeleporter")
        {
            bossScipt.canMove = false;
            anim.SetTrigger("TeleportIn");
            StartCoroutine(TeleportCoroutine());
        }
    }

    void Teleport()
    {
        int positionX = Random.Range(-20, 8);
        Vector3 newPos = new Vector3(positionX, this.transform.position.y, this.transform.position.z);
        //StartCoroutine(Teleport());
        this.transform.position = newPos;
        anim.SetTrigger("TeleportOut");
        StartCoroutine(CanMoveAgain());
        //bossScipt.canMove = true;
        //anim.SetTrigger("Walk");
        
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            StartCoroutine(TeleportCoroutine());
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }*/

  
       IEnumerator TeleportCoroutine()
       {
           yield return new WaitForSeconds(0.6f);
           Teleport();
       }

        public IEnumerator CanMoveAgain()
        {
        bossScipt.canMove = false;
        yield return new WaitForSeconds(1.6f);
            bossScipt.canMove = true;
        

        }
  
}
