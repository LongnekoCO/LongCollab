using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBoss : MonoBehaviour
{
    private BossPatrol bossScipt;

    // Start is called before the first frame update
    void Start()
    {
        bossScipt = this.GetComponentInParent<BossPatrol>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(BossCanMoveAgain());
        }
    }

    //void OnTriggerExit2D(Collider2D col)
    //{

    //        bossScipt.canMove = true;

    //}
    public IEnumerator BossCanMoveAgain()
    {
        bossScipt.canMove = false;
        yield return new WaitForSeconds(1.6f);
        bossScipt.canMove = true;
    }
}
