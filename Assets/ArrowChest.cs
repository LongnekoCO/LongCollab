using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowChest : MonoBehaviour
{
    public EnemyHealth healthScript;
    public Rigidbody2D itemA; 
    
    // Start is called before the first frame update
    void Start()
    {
        healthScript = this.GetComponent<EnemyHealth>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (healthScript.health <= 0)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        Instantiate(itemA, transform.position, transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            healthScript.TakeDamage(10);
        }

        if (col.gameObject.tag == "ShrinkingArrow")
        {
            StartCoroutine(Shrink());
        }
    }
    IEnumerator Shrink()
    {

        this.transform.localScale = new Vector3(this.transform.localScale.x / 2, this.transform.localScale.y / 2, this.transform.localScale.z / 2);        
        yield return new WaitForSeconds(5f);
        this.transform.localScale = new Vector3(this.transform.localScale.x * 2, this.transform.localScale.y * 2, this.transform.localScale.z * 2);

    }
}
