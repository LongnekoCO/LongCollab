using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBossPatrol : MonoBehaviour
{
    private Animator animator;
    private Collider2D collide2D;
    public int bossHealth;
    private int bossMaxHealth = 1000;
    public GameObject glueSpawners;
    public GameObject rootSpawners;
    public HealthBar healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        collide2D = this.GetComponent<Collider2D>();
        bossHealth = bossMaxHealth;
        healthBar.SetMaxHealth(bossHealth);
        //animator.SetTrigger("Idie");
    }

    // Update is called once per frame
    void Update()
    {
        if (bossHealth <= bossMaxHealth / 2)
        {
            InvokeRepeating("RootSpawning", 0, 10);
        }
        
        if (bossHealth <= (3 * bossMaxHealth) / 10)
        {
            InvokeRepeating("GlueSpawning", 0, 10);
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(100);
        }*/
    }

    void TakeDamage(int damage)
    {
        bossHealth -= damage;

        healthBar.SetHealth(bossHealth);
        
        animator.SetTrigger("Damage");

        ReturnIdle();

        if (bossHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        animator.SetTrigger("Die");
        Destroy(this.gameObject, 3f);
    }

    void RootSpawning()
    {
        StartCoroutine(RootSpawnerRoutine());
    }

    IEnumerator RootSpawnerRoutine()
    {
        rootSpawners.SetActive(true);
        yield return new WaitForSeconds(10f);
        rootSpawners.SetActive(false);
    }

    void GlueSpawning()
    {
        StartCoroutine(GlueSpawnerRoutine());
    }

    IEnumerator GlueSpawnerRoutine()
    {
        glueSpawners.SetActive(true);
        yield return new WaitForSeconds(10f);
        glueSpawners.SetActive(false);
    }

    void ReturnIdle()
    {
        animator.SetTrigger("Idie");
    }
}
