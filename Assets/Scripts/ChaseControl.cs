using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseControl : MonoBehaviour
{
    public List<LongBeeScript> enemyArray;
    public int num;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hi");
        if (collision.CompareTag("Player"))
        {
            
            foreach(LongBeeScript longBee in enemyArray)
            {
                longBee.chase = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (LongBeeScript longBee in enemyArray)
            {
                longBee.chase = false;
            }
        }
    }
}
