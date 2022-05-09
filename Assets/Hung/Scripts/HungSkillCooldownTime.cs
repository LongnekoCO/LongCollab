using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungSkillCooldownTime : MonoBehaviour
{
    [Header("Skill1")]
    public Image skill1;
    public float timeCooldown1;
    private bool isCooldown1 = false;
    
    [Header("Skill2")]
    public Image skill2;
    public float timeCooldown2;
    private bool isCooldown2 = false;
    
    [Header("Skill1")]
    public Image skill3;
    public float timeCooldown3;
    private bool isCooldown3 = false;
    
    // Start is called before the first frame update
    void Start()
    {
        skill1.fillAmount = 1;
        skill2.fillAmount = 1;
        skill3.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Skill1();
        Skill2();
        Skill3();
    }

    void Skill1()
    {
        if (Input.GetKeyDown(KeyCode.G) && isCooldown1 == false)
        {
            isCooldown1 = true;
            skill1.fillAmount = 0;
        }

        if (isCooldown1)
        {
            skill1.fillAmount += 1 / timeCooldown1 * Time.deltaTime;

            if (skill1.fillAmount >= 1)
            {
                skill1.fillAmount = 1;
                isCooldown1 = false;
            }
        }
    }

    void Skill2()
    {
        if (Input.GetKeyDown(KeyCode.C) && isCooldown2 == false)
        {
            isCooldown2 = true;
            skill2.fillAmount = 0;
        }

        if (isCooldown2)
        {
            skill2.fillAmount += 1 / timeCooldown2 * Time.deltaTime;

            if (skill2.fillAmount >= 1)
            {
                skill2.fillAmount = 1;
                isCooldown2 = false;
            }
        }
    }

    void Skill3()
    {
        if (Input.GetKeyDown(KeyCode.V) && isCooldown3 == false)
        {
            isCooldown3 = true;
            skill3.fillAmount = 0;
        }

        if (isCooldown3)
        {
            skill3.fillAmount += 1 / timeCooldown3 * Time.deltaTime;

            if (skill3.fillAmount >= 1)
            {
                skill3.fillAmount = 1;
                isCooldown3 = false;
            }
        }
    }
}
