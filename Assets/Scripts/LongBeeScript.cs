using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBeeScript : MonoBehaviour
{

    public float speed;
    public bool chase = false;
    public Transform startingPoint;
    private GameObject player;
    public int beeNum;
    public LongBeeHive BH;
    public ChaseControl CC;
    // Start is called before the first frame update
    void Start()
    {
        CC = GameObject.Find("ChaseTrigger").GetComponent<ChaseControl>();  
        BH = GameObject.Find("BeeHive").GetComponent<LongBeeHive>();
        player = GameObject.FindGameObjectWithTag("Player");
        BH.CurrentBee += 1;
        CC.enemyArray.Add(this);
        startingPoint = BH.SpawnPoint[BH.currentSpawn];
        BH.currentSpawn += 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player==null)
        {
            return;
        }
        else
        {
            if(chase==true)
            {
                Chase();
            }
            else
            {
                ReturnToStart();
            }
            
            Flip();
        }
    }
   private void Chase()
   {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
   }
    private void Flip()
    {
        if(transform.position.x>player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    private void ReturnToStart()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.transform.position, speed * Time.deltaTime);
    }
    private void Death()
    {
        BH.CurrentBee -= 1;
        Destroy(this.gameObject);
    }
}
