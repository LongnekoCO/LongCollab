using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HungBossTeleporter : MonoBehaviour
{
    private GameObject currentTeleporter;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        StartCoroutine(TeleportCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTeleporter != null)
        {
            //this.transform.position = currentTeleporter.GetComponent<Waypoint>().TeleportTarget().position;
        }
    }

    void Teleport()
    {
        int positionX = Random.Range(-9, 1);
        Vector3 temp = new Vector3(positionX, this.transform.position.y, this.transform.position.z);
        //StartCoroutine(Teleport());
        this.transform.position = temp;
        anim.SetTrigger("TeleportOut");
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
        yield return new WaitForSeconds(0.5f);
        Teleport();
    }
}
