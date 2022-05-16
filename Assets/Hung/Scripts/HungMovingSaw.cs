using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungMovingSaw : MonoBehaviour
{
    public float moveSpeed;
    public List<Transform> target = new List<Transform>();
    public bool isMovingForward;
    public bool isMovingBackward;
    public PlayerMovementScript player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Dog").GetComponent<PlayerMovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = moveSpeed * Time.deltaTime;

        if (isMovingForward == true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target[1].position, move);
        }
        else if (isMovingBackward == true)
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

        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "Saw")
        {
            player.TakeDamage(10);
        }
    }
}
