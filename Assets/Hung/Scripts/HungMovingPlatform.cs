using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungMovingPlatform : MonoBehaviour
{
    public float moveSpeed;
    public List<Transform> target = new List<Transform>();
    public bool isMovingForward;
    public bool isMovingBackward;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = moveSpeed * Time.deltaTime;

        if (isMovingForward == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target[1].position, move);
        }
        else if(isMovingBackward == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target[0].position, move);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "Waypoint")
        {
            isMovingForward = true;
            isMovingBackward = false;
        }
        else if (collision.gameObject.tag == "WaypointBack")
        {
            isMovingForward = false;
            isMovingBackward = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
        //collision.transform.SetParent(null);
    }

}
