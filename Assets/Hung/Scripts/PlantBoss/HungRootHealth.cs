using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungRootHealth : MonoBehaviour
{
    public int health;
    private int maxHealth = 50;
    private PlayerMovementScript player;
    public HungHealthBar healthBar;
    private HungRootSpawner rootSpawner1;
    private HungRootSpawner rootSpawner2;
    private HungRootSpawner rootSpawner3;
    private HungRootSpawner rootSpawner4;
    private HungRootSpawner rootSpawner5;
    private HungRootSpawner rootSpawner6;
    public GameObject canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        rootSpawner1 = GameObject.Find("RootSpawner").GetComponent<HungRootSpawner>();
        rootSpawner2 = GameObject.Find("RootSpawner (1)").GetComponent<HungRootSpawner>();
        rootSpawner3 = GameObject.Find("RootSpawner (2)").GetComponent<HungRootSpawner>();
        rootSpawner4 = GameObject.Find("RootSpawner (3)").GetComponent<HungRootSpawner>();
        rootSpawner5 = GameObject.Find("RootSpawner (4)").GetComponent<HungRootSpawner>();
        rootSpawner6 = GameObject.Find("RootSpawner (5)").GetComponent<HungRootSpawner>();

        player = GameObject.Find("Player").GetComponent<PlayerMovementScript>();
        
        health = maxHealth;
        healthBar.SetMaxHealth(health);

        //InvokeRepeating("HealthBarEnable", rootSpawner.timeStart, rootSpawner.timeDelay);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(50);
        }*/
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        //this.gameObject.SetActive(false);
        Destroy(this.gameObject);
        //canvas.SetActive(false);
    }

    void HealthBarEnable()
    {
        StartCoroutine(HealthBarRoutine());
    }

    IEnumerator HealthBarRoutine()
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(4f);
        canvas.SetActive(false);
    }
}
