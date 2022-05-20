using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private const float GRAB_DISTANCE = 5f;
    [SerializeField] private PlayerBowAndPowers player;
    [SerializeField] private Transform shieldHolder;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private State state;
    private TrailRenderer trail;
    

    private enum State{
        WithPlayer, 
        Thrown,
        Recalling, 
    };
    

    private void Awake()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        rb = this.GetComponent<Rigidbody2D>();
        state = State.Recalling;
        trail = this.GetComponent<TrailRenderer>();
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 1);
    }

    void FixedUpdate()
    {
        switch (state)
        {
            case State.Thrown:
                TryPlayerGrabShield();
                break;
            case State.Recalling: 
                Vector3 dirToPlayer = (player.GetPosition() - transform.position).normalized;
                float recallSpeed = 50f;
                rb.velocity = dirToPlayer * recallSpeed;
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                //var step = recallSpeed * Time.deltaTime;
                //transform.position = Vector3.MoveTowards(transform.position, player.GetPosition(), step);
                TryPlayerGrabShield();
                break;
        }

    }

    void LateUpdate()
    {
        switch (state)
        {
            case State.WithPlayer:
                transform.position = shieldHolder.position;
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 1);
                break;
        }
    }

    private void TryPlayerGrabShield()
    {
        if (Vector3.Distance(transform.position, player.GetPosition()) < GRAB_DISTANCE)
        {
            state = State.WithPlayer;
            trail.enabled = false;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }
    }

    public void ThrowShield(Vector3 throwDir)
    {
        transform.position = player.GetPosition() + throwDir * (GRAB_DISTANCE + 1f);
        float throwForce = 50f;
        rb.isKinematic = false;
        rb.AddForce(throwDir * throwForce, ForceMode2D.Impulse);
        trail.enabled = true;
        state = State.Thrown;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 1);
    }

    public void Recall()
    {
        state = State.Recalling;
    }

    public bool IsWithPlayer()
    {
        return state == State.WithPlayer;
    }


    
}
