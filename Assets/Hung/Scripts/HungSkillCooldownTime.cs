using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungSkillCooldownTime : MonoBehaviour
{
    public float timeCooldown;
    private bool isCooldown = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Skill1();
    }

    void Skill1()
    {
        if (Input.GetKeyDown(KeyCode.G) && isCooldown == false)
        {
            isCooldown = true;
        }
    }
}
