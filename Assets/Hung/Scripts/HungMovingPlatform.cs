using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungMovingPlatform : MonoBehaviour
{
    public float moveSpeed;

    public Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = moveSpeed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, target.position, move);
    }

    public void Flip()
    {
        Vector2 enemyFilp = this.transform.localScale;
        enemyFilp.x = enemyFilp.x * -1;
        this.transform.localScale = enemyFilp;
    }
}
