using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungPlayerFind : MonoBehaviour
{
    public LayerMask mask;
    public Transform player;
    private HungEnemy5Patrol enemy5;
    public float sightRange;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy5 = GameObject.Find("Enemy5").GetComponent<HungEnemy5Patrol>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToPlayer = player.position - this.transform.position;
        RaycastHit2D hitPlayer = Physics2D.Raycast(this.transform.position, directionToPlayer, Mathf.Infinity, mask);
        Debug.DrawRay(this.transform.position, directionToPlayer, Color.red);

        if (EnemyCanSeePlayer() && hitPlayer.distance < sightRange)
        {
            if (hitPlayer.collider.tag == "Player")
            {
                Debug.Log("shoot");
                Debug.DrawRay(this.transform.position, directionToPlayer, Color.blue);
                enemy5.Attack();
            }
        }
        else
        {
            enemy5.Move();
        }
    }

    private bool EnemyCanSeePlayer()
    {
        if (enemy5.facingRight == true && player.position.x > this.transform.position.x)
        {
            return true;
        }
        else if (enemy5.facingRight == false && player.position.x < this.transform.position.x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
