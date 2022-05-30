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

    public int energy = 150; //testing only
    public int currentEnergy;
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

    public Shield shield;
    public GameObject capShield;

    public Mjolnir hammer;
    public GameObject mHammer;

    Sprite weaponImagee;
    public GameObject weaponImage;

    public GameObject unitRoot;
    Animator anim;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    float nextAttackTime = 0f;
    public float attackRate = 1.5f;
    public bool canMelee;

    public GameObject shieldHealthBar;

    public GameObject thorLightning;
    public bool canLightning = true;

    public bool canThrowHammer = true;

    public IceBendingTrigger rangeScript;
    public Transform iceDetect;

    // Start is called before the first frame update
    void Start()
    {
        iceDetect = this.gameObject.transform.GetChild(5);
        boulderDefSpawn.SetActive(false);
        boulderAttackSpawn.SetActive(false);
        bow.SetActive(false);
        capShield.SetActive(false);
        mHammer.SetActive(false);
        playerMovementScript = this.GetComponent<PlayerMovementScript>();
        rangeScript = iceDetect.GetComponent<IceBendingTrigger>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
         
        currentEnergy = energy;
        energyBar.SetMaxEnergy(energy);

        abilityImage1.fillAmount = 1;
        abilityImage2.fillAmount = 1;
        abilityImage3.fillAmount = 1;

        arrowDisplay.SetActive(false);

        unitRoot = this.transform.Find("UnitRoot").gameObject;
        if (unitRoot != null)
        {
            anim = unitRoot.GetComponent<Animator>();
        }

        canMelee = true;
        weaponImagee = Resources.Load<Sprite>("Punch");
        weaponImage.GetComponent<Image>().sprite = weaponImagee;

        shieldHealthBar.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Bow();
        Power();
        Power2();
        Power3();
        ShieldThrown();
        ActivateShield();
        MeleeAttack();
        AirMeleeAttack();
        ActivateMjolnir();
        //HammerSummonLightning();
        HammerThrown();


        if(!bow.activeSelf && !capShield.activeSelf && !mHammer.activeSelf)
        {
            weaponImagee = Resources.Load<Sprite>("Punch");
            weaponImage.GetComponent<Image>().sprite = weaponImagee;
        }
        

    }

    public void MeleeAttack()
    {
        if(playerMovementScript.isGrounded && canMelee == true && !bow.activeSelf && !capShield.activeSelf && !mHammer.activeSelf)
        {
            if (Input.GetMouseButtonUp(0))
            {
                anim.SetTrigger("isAttackNormal");
                

                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<EnemyHealth>().TakeDamage(15);
                    Debug.Log("we hit" + enemy.name);
                }
                StartCoroutine(MeleeCooldown());
            }
        }

        else
        {
            anim.SetTrigger("isIdle");
        }
        
    }

    public void AirMeleeAttack()
    {
        if (!playerMovementScript.isGrounded && canMelee == true && !bow.activeSelf && !capShield.activeSelf && !mHammer.activeSelf)
        {
            if (Input.GetMouseButtonUp(0))
            {
                anim.SetTrigger("isSkillNormal");


                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<EnemyHealth>().TakeDamage(20);
                    Debug.Log("we hit" + enemy.name);
                }
                StartCoroutine(MeleeCooldown());
            }
        }

        else
        {
            anim.SetTrigger("isIdle");
        }

    }

    IEnumerator MeleeCooldown()
    {
        canMelee = false;
        yield return new WaitForSeconds(1f);
        canMelee = true;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void Power()
    {
        if (Input.GetKeyDown(KeyCode.G) && isCooldown1 == false && currentEnergy - 30 >= 0)
        {
            //anim.SetTrigger("isIdle");
            currentEnergy -= 30;
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
            currentEnergy -= 30;
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
        if (Input.GetKeyDown(KeyCode.V) && inRange == true && canIce == true && currentEnergy - 30 >= 0 && isCooldown3 == false)
        {
            //anim.SetTrigger("isIdle");
            currentEnergy -= 30;
            foreach (GameObject enemie in rangeScript.enemiesInRange)
            {
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

    public void UseEnergy(int energy1)
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!bow.activeSelf)
            {
                capShield.SetActive(false);
                shieldHealthBar.SetActive(false);
                bow.SetActive(true);
                arrowDisplay.SetActive(true);
                weaponImagee = Resources.Load<Sprite>("Bow_5");
                weaponImage.GetComponent<Image>().sprite = weaponImagee;
            }

            else
            {
                bow.SetActive(false);
                arrowDisplay.SetActive(false);
            }
        }
    }

    void ActivateShield()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(!capShield.activeSelf)
            {
                weaponImagee = Resources.Load<Sprite>("ShieldImage");
                weaponImage.GetComponent<Image>().sprite = weaponImagee;
                capShield.SetActive(true);
                shieldHealthBar.SetActive(true);
                bow.SetActive(false);
                arrowDisplay.SetActive(false);
            }
            
            

            else if(capShield.activeSelf)
            {
                capShield.SetActive(false);
                shieldHealthBar.SetActive(false);
            }


        }

       
    }

    void ActivateMjolnir()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (!mHammer.activeSelf)
            {
                //weaponImagee = Resources.Load<Sprite>("ShieldImage");
                //weaponImage.GetComponent<Image>().sprite = weaponImagee;
                capShield.SetActive(false);
                shieldHealthBar.SetActive(false);
                bow.SetActive(false);
                arrowDisplay.SetActive(false);
                mHammer.SetActive(true);
            }



            else if (mHammer.activeSelf)
            {
                mHammer.SetActive(false);
                //shieldHealthBar.SetActive(false);
            }


        }


    }

    void HammerThrown()
    {
        if(mHammer.activeSelf)
        {
            if (Input.GetMouseButtonDown(0) && canThrowHammer)
            {
                if(hammer.IsWithPlayer())
                {
                    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3 throwDir = (mousePosition - GetPosition()).normalized;
                    hammer.ThrowHammer(throwDir);
                }

                else
                {
                    hammer.Recall();
                }
            }
            if (Input.GetKey(KeyCode.R))
            {
                if (hammer.IsWithPlayer())
                {
                    hammer.Lightning();
                    canThrowHammer = false;
                    if(Input.GetMouseButton(1) && inRange && canLightning)
                    {
                        
                        foreach (GameObject enemie in rangeScript.enemiesInRange)
                        {
                                if(enemie != null)
                                {
                                    Vector2 lightningHit = new Vector2(enemie.transform.position.x, enemie.transform.position.y + 2.2f);
                                    Instantiate(thorLightning, lightningHit, Quaternion.identity);

                                    StartCoroutine(Lightning());
                                }
                                
                            
                            
                        }
                    }
                    
                    //Debug.Log("Summon");
                }
            }
            else if (Input.GetKeyUp(KeyCode.R))
            {
                canThrowHammer = true;
                hammer.lightning.SetActive(false);
                //Debug.Log("Not Summon");
            }

        }
    }

    //void HammerSummonLightning()
    //{
    //    if(mHammer.activeSelf)
    //    {
    //        if(Input.GetKey(KeyCode.R))
    //        {
    //            if(hammer.IsWithPlayer())
    //            {
    //                hammer.Lightning();
    //            }
    //        }
    //        else if(Input.GetKeyUp(KeyCode.R))
    //        {
    //            hammer.IsWithPlayer();
    //        }
    //    }
    //}

    void ShieldThrown()
    {
        if(capShield.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (shield.IsWithPlayer())
                {
                    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector3 throwDir = (mousePosition - GetPosition()).normalized;
                    shield.ThrowShield(throwDir);
                }

                else
                {
                    shield.Recall();
                }
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

    IEnumerator Lightning()
    {
        canLightning = false;
        yield return new WaitForSeconds(2f);
        canLightning = true;
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

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
