using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed;
    public List<Transform> target = new List<Transform>();
    public bool isMovingUp;
    public bool isMovingDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = moveSpeed * Time.deltaTime;

        if (isMovingUp == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target[0].position, move);
        }
        else if (isMovingDown == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target[1].position, move);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Waypoint")
        {
            isMovingUp = true;
            isMovingDown = false;
        }
        else if (collision.gameObject.tag == "WaypointBack")
        {
            isMovingUp = false;
            isMovingDown = true;
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }    
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }*/
}
