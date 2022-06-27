using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBendingTrigger : MonoBehaviour
{
    private PlayerBowAndPowers playerScript;
    public List<GameObject> enemiesInRange = new List<GameObject>(); 
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = this.GetComponentInParent<PlayerBowAndPowers>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            playerScript.inRange = true;
            enemiesInRange.Add(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Boss")
        {
            playerScript.inRange = true;
            enemiesInRange.Add(collision.gameObject);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            playerScript.inRange = false;
            if(enemiesInRange.Contains(collision.gameObject))
            {
                enemiesInRange.Remove(collision.gameObject);
            }
        }

        else if (collision.gameObject.tag == "Boss")
        {
            playerScript.inRange = false;
            if (enemiesInRange.Contains(collision.gameObject))
            {
                enemiesInRange.Remove(collision.gameObject);
            }
        }
    }
}
