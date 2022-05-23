using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    private const float GRAB_DISTANCE = 2f;
    [SerializeField] private PlayerBowAndPowers player;
    [SerializeField] private Transform shieldHolder;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private State state;
    private TrailRenderer trail;

    public int health = 100; //testing only

    public int currentHealth;
    public HungHealthBar shieldHealthBar;

    Sprite shieldImagee;
    public GameObject shieldImage;
    

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
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -1);
        currentHealth = health;
        shieldHealthBar.SetMaxHealth(health);

        //shieldImagee = Resources.Load<Sprite>("CapShield");
        //shieldImage.GetComponent<SpriteRenderer>().sprite = shieldImagee;
    }

    void FixedUpdate()
    {
        switch (state)
        {
            case State.Thrown:
                TryPlayerGrabShield();
                break;
            case State.Recalling: 
                Vector3 dirToPlayer =  (player.GetPosition() - transform.position).normalized;
                float recallSpeed = 50f;
                rb.velocity = dirToPlayer * recallSpeed;
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -1);
                //var step = recallSpeed * Time.deltaTime;
                //transform.position = Vector3.MoveTowards(transform.position, player.GetPosition(), step);
                TryPlayerGrabShield();
                break;
        }

        ShieldState();

    }

    void LateUpdate()
    {
        switch (state)
        {
            case State.WithPlayer:
                transform.position = shieldHolder.position;
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -1);
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
        float throwForce = 250f;
        rb.isKinematic = false;
        rb.AddForce(throwDir * throwForce, ForceMode2D.Impulse);
        trail.enabled = true;
        state = State.Thrown;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -1);
    }

    public void Recall()
    {
        state = State.Recalling;
    }

    public bool IsWithPlayer()
    {
        return state == State.WithPlayer;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentHealth -= 5;
        shieldHealthBar.SetHealth(currentHealth);
        Debug.Log("We hit " + collision.gameObject.name);
    }

    void ShieldState()
    {
        if (currentHealth <= (health/10))
        {
            shieldImagee = Resources.Load<Sprite>("BrokenShield3");
            this.GetComponent<SpriteRenderer>().sprite = shieldImagee;
            shieldImage.GetComponent<Image>().sprite = shieldImagee;
        }

        else if(currentHealth > (health/10) && currentHealth <= (health/2))
        {
            shieldImagee = Resources.Load<Sprite>("CapShield50");
            this.GetComponent<SpriteRenderer>().sprite = shieldImagee;
            shieldImage.GetComponent<Image>().sprite = shieldImagee;
        }

        else
        {
            shieldImagee = Resources.Load<Sprite>("CapShield");
            this.GetComponent<SpriteRenderer>().sprite = shieldImagee;
            shieldImage.GetComponent<Image>().sprite = shieldImagee;
        }
    }



}
