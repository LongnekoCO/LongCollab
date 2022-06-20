using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSpike : MonoBehaviour
{
    //private Collider2D collider;
    private PlayerMovementScript player;
    private Animator animator;
    public float timeSeconds;

    // Start is called before the first frame update
    void Start()
    {
        //collider = this.GetComponent<Collider2D>();
        player = GameObject.Find("Player").GetComponent<PlayerMovementScript>();
        animator = this.GetComponent<Animator>();
        InvokeRepeating("AnimationStart", 1f, timeSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.TakeDamage(20);
        }
    }

    void AnimationStart()
    {
        StartCoroutine(AnimationRoutine());
    }
    
    IEnumerator AnimationRoutine()
    {
        animator.SetTrigger("Normal");
        yield return new WaitForSeconds(timeSeconds);
        animator.SetTrigger("Reverse");
        yield return new WaitForSeconds(timeSeconds);
        animator.SetTrigger("Normal");
    }
}
