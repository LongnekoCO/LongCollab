using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBowAndPowers : MonoBehaviour
{
    public GameObject bow;
    public GameObject boulderDef;
    public GameObject boulderDefSpawn;
    public bool inRange;
    public bool canIce = true;
    public GameObject iceAttack;
    public GameObject boulderAttack;
    public GameObject boulderAttackSpawn;

    public GameObject[] enemies;

    private PlayerMovementScript playerMovementScript; 

    // Start is called before the first frame update
    void Start()
    {
        boulderDefSpawn.SetActive(false);
        boulderAttackSpawn.SetActive(false);
        bow.SetActive(false);
        playerMovementScript = this.GetComponent<PlayerMovementScript>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        BowAndPower();
    }

    void BowAndPower()
    {
         if (Input.GetKeyDown(KeyCode.G))
        {
            //anim.SetTrigger("isIdle");
            boulderDefSpawn.SetActive(true);
            Instantiate(boulderDef, boulderDefSpawn.transform.position, Quaternion.identity);
            playerMovementScript.canMovee = false;
            StartCoroutine(BoulderFall());
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            //anim.SetTrigger("isIdle");
            boulderAttackSpawn.SetActive(true);
            Instantiate(boulderAttack, boulderAttackSpawn.transform.position, Quaternion.identity);
            playerMovementScript.canMovee = false;
            StartCoroutine(BoulderAttack());
        }

        else if (Input.GetKeyDown(KeyCode.V) && inRange == true && canIce == true)
        {
            //anim.SetTrigger("isIdle");
            foreach(GameObject enemie in enemies)
            {
                Instantiate(iceAttack, enemie.transform.position, Quaternion.identity);
                StartCoroutine(Ice());
            }
            
        }

        else if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!bow.activeSelf)
            {
                bow.SetActive(true);
            }

            else
            {
                bow.SetActive(false);
            }

        }
    }

    IEnumerator BoulderFall()
    {
        yield return new WaitForSeconds(1f);
        boulderDefSpawn.SetActive(false);
        playerMovementScript.canMovee = true;
    }

    IEnumerator BoulderAttack()
    {
        yield return new WaitForSeconds(2f);
        boulderAttackSpawn.SetActive(false);
        playerMovementScript.canMovee = true;
    }

    IEnumerator Ice()
    {
        canIce = false;
        yield return new WaitForSeconds(2f);
        canIce = true;
    }

}
