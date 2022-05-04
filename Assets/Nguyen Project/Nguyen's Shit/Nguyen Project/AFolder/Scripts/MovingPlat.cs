using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    public Transform pos3, pos4;
    public float speed;
    public Transform startPos;
    public float timer = 2f;
    public bool canMove;

    Vector3 nextPos; 

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pos3.position)
        {
            canMove = false;
            nextPos = pos4.position;
            timer -= 1 * Time.deltaTime;
            if (timer <= 0f)
            {
                canMove = true;
                timer = 2f;
            }

            
        }

        if (transform.position == pos4.position)
        {
            canMove = false;
            nextPos = pos3.position;
            timer -= 1 * Time.deltaTime;
            if (timer <= 0f)
            {
                //transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
                canMove = true;
                timer = 2f;
            }


        }
        if(canMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

        }
       // transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }   
   

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos3.position, pos4.position);
    }
}
