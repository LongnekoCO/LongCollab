using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootHealth : MonoBehaviour
{
    public int health;
    private int maxHealth = 50;
    private PlayerMovementScript player;
    public HealthBar healthBar;
    private RootSpawner rootSpawner1;
    private RootSpawner rootSpawner2;
    private RootSpawner rootSpawner3;
    private RootSpawner rootSpawner4;
    private RootSpawner rootSpawner5;
    private RootSpawner rootSpawner6;
    public GameObject canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        rootSpawner1 = GameObject.Find("RootSpawner").GetComponent<RootSpawner>();
        rootSpawner2 = GameObject.Find("RootSpawner (1)").GetComponent<RootSpawner>();
        rootSpawner3 = GameObject.Find("RootSpawner (2)").GetComponent<RootSpawner>();
        rootSpawner4 = GameObject.Find("RootSpawner (3)").GetComponent<RootSpawner>();
        rootSpawner5 = GameObject.Find("RootSpawner (4)").GetComponent<RootSpawner>();
        rootSpawner6 = GameObject.Find("RootSpawner (5)").GetComponent<RootSpawner>();
        
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
