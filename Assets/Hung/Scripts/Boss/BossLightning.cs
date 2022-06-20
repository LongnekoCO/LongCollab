using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*******************************************************
Author Name: Le Hoang Hung
Date: 22/11/2021
Object holding the script: BossAttackBox
Summary:
The lightning attack damage
Player will lose one items in the inventory 

Change log:


*******************************************************/

public class BossLightning : MonoBehaviour
{
    private HungBossPatrol bossScript;
    public GameObject lightning;
    public List<GameObject> strikeTarget;
    public GameObject warningSign;
    public float timeDelay;
    public float timeStart;

    // Start is called before the first frame update
    void Start()
    {
        bossScript = GameObject.Find("Boss1").GetComponent<HungBossPatrol>();
        InvokeRepeating("LightningStrike", timeStart, timeDelay); //lighting strike time
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LightningStrike()
    {
        //Make a random number to spawn the lightning
        int rand = Random.Range(0, 3);
        if (rand == 0)
        {
            Instantiate(warningSign, strikeTarget[0].transform.position, Quaternion.identity);
            StartCoroutine(LightningRoutine1());
            //GameObject lightningClone = Instantiate(lightning, strikeTarget[0].transform.position, Quaternion.identity);
            //Destroy(lightningClone, 3f);
        }
        else if (rand == 1)
        {
            Instantiate(warningSign, strikeTarget[1].transform.position, Quaternion.identity);
            StartCoroutine(LightningRoutine2());
            //GameObject lightningClone = Instantiate(lightning, strikeTarget[1].transform.position, Quaternion.identity);
            //Destroy(lightningClone, 3f);
        }
        else if (rand == 2)
        {
            Instantiate(warningSign, strikeTarget[2].transform.position, Quaternion.identity);
            StartCoroutine(LightningRoutine3());
            //GameObject lightningClone = Instantiate(lightning, strikeTarget[2].transform.position, Quaternion.identity);
            //Destroy(lightningClone, 3f);
        }
    }

    IEnumerator WarningRoutine()
    {
        Instantiate(warningSign, strikeTarget[1].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2.5f);
    }

    IEnumerator LightningRoutine1()
    {
        Instantiate(warningSign, strikeTarget[0].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2.5f);
        GameObject lightningClone = Instantiate(lightning, strikeTarget[0].transform.position, Quaternion.identity);
        Destroy(lightningClone, 1.5f);
    }
    
    IEnumerator LightningRoutine2()
    {
        Instantiate(warningSign, strikeTarget[1].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2.5f);
        GameObject lightningClone = Instantiate(lightning, strikeTarget[1].transform.position, Quaternion.identity);
        Destroy(lightningClone, 1.5f);
    }
    
    IEnumerator LightningRoutine3()
    {
        Instantiate(warningSign, strikeTarget[2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2.5f);
        GameObject lightningClone = Instantiate(lightning, strikeTarget[2].transform.position, Quaternion.identity);
        Destroy(lightningClone, 1.5f);
    }

    

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerScript.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }*/
}
