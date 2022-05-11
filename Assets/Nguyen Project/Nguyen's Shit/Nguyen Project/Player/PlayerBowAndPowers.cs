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

    public float energy = 150; //testing only
    public float currentEnergy;
    public EnergyBar energyBar;

    private Coroutine regain;
    private WaitForSeconds regainTick = new WaitForSeconds(0.1f);


    // Start is called before the first frame update
    void Start()
    {
        boulderDefSpawn.SetActive(false);
        boulderAttackSpawn.SetActive(false);
        bow.SetActive(false);
        playerMovementScript = this.GetComponent<PlayerMovementScript>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
         
        currentEnergy = energy;
        energyBar.SetMaxEnergy(energy);
    }

    // Update is called once per frame
    void Update()
    {
        Bow();
        Power();
    }

    void Power()
    {
        if (currentEnergy - 30 >= 0)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {

                //anim.SetTrigger("isIdle");
                currentEnergy -= 30f;
                boulderDefSpawn.SetActive(true);
                Instantiate(boulderDef, boulderDefSpawn.transform.position, Quaternion.identity);
                playerMovementScript.canMovee = false;

                StartCoroutine(BoulderFall());

                if (regain != null)
                {
                    StopCoroutine(regain);
                }

                regain = StartCoroutine(RegainStamina());
            }





            else if (Input.GetKeyDown(KeyCode.C))
            {

                //anim.SetTrigger("isIdle");
                currentEnergy -= 30f;
                boulderAttackSpawn.SetActive(true);
                Instantiate(boulderAttack, boulderAttackSpawn.transform.position, Quaternion.identity);
                playerMovementScript.canMovee = false;

                StartCoroutine(BoulderAttack());

                if (regain != null)
                {
                    StopCoroutine(regain);
                }

                regain = StartCoroutine(RegainStamina());




            }

            else if (Input.GetKeyDown(KeyCode.V) && inRange == true && canIce == true)
            {

                //anim.SetTrigger("isIdle");
                foreach (GameObject enemie in enemies)
                {
                    currentEnergy -= 30f;
                    Instantiate(iceAttack, enemie.transform.position, Quaternion.identity);

                    StartCoroutine(Ice());
                }

                if (regain != null)
                {
                    StopCoroutine(regain);
                }

                regain = StartCoroutine(RegainStamina());



            }
        }

        else 
        {
            Debug.Log("Not enough juice");
        }
            
    
        
    }

    void Bow()
    {
        if (Input.GetKeyDown(KeyCode.Z))
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

    private IEnumerator RegainStamina()
    {
        yield return new WaitForSeconds(2);

        while (currentEnergy < energy)
        {
            currentEnergy += energy / 100;
            energyBar.SetEnergy(currentEnergy);
            yield return regainTick;

        }
        regain = null;
    }

    public void RegainEnergy(int regain)
    {
        currentEnergy = currentEnergy + regain;
        energyBar.SetEnergy(currentEnergy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ViagraPill")
        {
            StartCoroutine(ViagraReaction());
        }
    }

    IEnumerator ViagraReaction()
    {
        bow.GetComponent<Bow>().fireRate = 0f;
        yield return new WaitForSeconds(5f);
        bow.GetComponent<Bow>().fireRate = 0.5f;
    }

}
