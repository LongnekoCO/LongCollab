using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongBoss2 : MonoBehaviour {

    public int health;
    public int damage;
    private float timeBtwDamage = 1.5f;
    public PlayerMovementScript player;

    public Animator camAnim;
    public Slider healthBar;
    private Animator anim;
    public bool isDead;

    private void Start()
    {
        
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovementScript>();
        if (health <= 25) {
            anim.SetTrigger("stageTwo");
        }

        if (health <= 0) {
            anim.SetTrigger("death");
            Destroy(this.gameObject, 3f);
        }

        // give the player some time to recover before taking more damage !
        if (timeBtwDamage > 0) {
            timeBtwDamage -= Time.deltaTime;
        }

        healthBar.value = health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // deal the player damage ! 
        if (other.CompareTag("Player") && isDead == false) {
            if (timeBtwDamage <= 0) {
                camAnim.SetTrigger("shake");
                //deal damage to player
                player.TakeDamage(20);
                
            }
        } 
    }

    public void TakeDamage(int dam)
    {
        health -= dam;        
    }
}
