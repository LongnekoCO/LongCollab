using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallShooter : MonoBehaviour
{
    public Rigidbody2D fireBall;
    public float speed;
    private bool facingRight;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireBallShoot", 1f, 5f);
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireBallShoot()
    {
        if (this.transform.localScale.x >= 1)
        { 
            Rigidbody2D latestFireball = Instantiate(fireBall, this.transform.position, Quaternion.identity);

            latestFireball.AddForce(new Vector2(500, 0) * speed);

            FireballFlip();
        }
        else if (this.transform.localScale.x <= -1)
        {
            Rigidbody2D latestFireball = Instantiate(fireBall, this.transform.position, Quaternion.identity);

            latestFireball.AddForce(new Vector2(-500, 0) * speed);

            FireballFlip();
        }
    }

    public void FireballFlip()
    {
        //Debug.Log("flip");
        Vector2 ballFlip = fireBall.transform.localScale;
        ballFlip.x = ballFlip.x * -1;
        fireBall.transform.localScale = ballFlip;
        facingRight = !facingRight;
    }
}
