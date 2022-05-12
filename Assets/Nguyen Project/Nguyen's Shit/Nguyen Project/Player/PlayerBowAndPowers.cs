using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    public Image abilityImage1;
    public Image abilityImage2;
    public Image abilityImage3;

    public float coolDown1 = 3f;
    public float coolDown2 = 5f;
    public float coolDown3 = 4f;

    public bool isCooldown1 = false;
    public bool isCooldown2 = false;
    public bool isCooldown3 = false;

    public GameObject arrowDisplay;



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

        abilityImage1.fillAmount = 1;
        abilityImage2.fillAmount = 1;
        abilityImage3.fillAmount = 1;

        arrowDisplay.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Bow();
        Power();
        Power2();
        Power3();
    }

    void Power()
    {
        
            if (Input.GetKeyDown(KeyCode.G) && isCooldown1 == false && currentEnergy - 30 >= 0)
            {

                //anim.SetTrigger("isIdle");
                currentEnergy -= 30f;
                boulderDefSpawn.SetActive(true);
                Instantiate(boulderDef, boulderDefSpawn.transform.position, Quaternion.identity);
                playerMovementScript.canMovee = false;
                isCooldown1 = true;
                abilityImage1.fillAmount = 0; 

                

                StartCoroutine(BoulderFall());



                if (regain != null)
                {
                    StopCoroutine(regain);
                }

                regain = StartCoroutine(RegainStamina());
            }

        if (isCooldown1)
        {
            abilityImage1.fillAmount += 1 / coolDown1 * Time.deltaTime;
            if (abilityImage1.fillAmount == 1)
            {
                //abilityImage1.fillAmount = 0;
                isCooldown1 = false;

            }
        }


    }

    void Power2()
    {
        if (Input.GetKeyDown(KeyCode.C) && isCooldown2 == false && currentEnergy - 30 >= 0)
        {

            //anim.SetTrigger("isIdle");
            currentEnergy -= 30f;
            boulderAttackSpawn.SetActive(true);
            Instantiate(boulderAttack, boulderAttackSpawn.transform.position, Quaternion.identity);
            playerMovementScript.canMovee = false;
            isCooldown2 = true;
            abilityImage2.fillAmount = 0;


            StartCoroutine(BoulderAttack());

            if (regain != null)
            {
                StopCoroutine(regain);
            }

            regain = StartCoroutine(RegainStamina());


        }

        if (isCooldown2)
        {
            abilityImage2.fillAmount += 1 / coolDown2 * Time.deltaTime;
            if (abilityImage2.fillAmount == 1)
            {
                //abilityImage2.fillAmount = 0;
                isCooldown2 = false;

            }
        }
    }

    void Power3()
    {
        if (Input.GetKeyDown(KeyCode.V) && inRange == true && canIce == true && currentEnergy - 30 >= 0 && isCooldown3 == true)
        {

            //anim.SetTrigger("isIdle");
            foreach (GameObject enemie in enemies)
            {
                currentEnergy -= 30f;
                Instantiate(iceAttack, enemie.transform.position, Quaternion.identity);

                StartCoroutine(Ice());
            }
            isCooldown3 = true;
            abilityImage3.fillAmount = 0;

            


            if (regain != null)
            {
                StopCoroutine(regain);
            }

            regain = StartCoroutine(RegainStamina());



        }

        if (isCooldown3)
        {
            abilityImage3.fillAmount += 1 / coolDown3 * Time.deltaTime;
            if (abilityImage3.fillAmount == 1)
            {
                //abilityImage3.fillAmount = 0;
                isCooldown3 = false;

            }
        }
    }

    public void UseEnergy(float energy1)
    {
        currentEnergy -= energy1; 
         if (regain != null)
        {
            StopCoroutine(regain);
        }

        regain = StartCoroutine(RegainStamina());

    }

    void Bow()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!bow.activeSelf)
            {
                bow.SetActive(true);
                arrowDisplay.SetActive(true);
            }

            else
            {
                bow.SetActive(false);
                arrowDisplay.SetActive(false);
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
