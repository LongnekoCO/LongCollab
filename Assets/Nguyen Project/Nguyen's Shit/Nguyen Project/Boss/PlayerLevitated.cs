using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevitated : MonoBehaviour
{
    public bool isLevitated = false;
    public bool canMovee = true;
    public float timer = 1f;
    Animator anim;

   
    public float speed;
    public Transform starPos;

    Vector3 nextPos;
    public Rigidbody2D playerRigidbody;
    public Transform player;
    public float pushForce = 5;
    Vector3 temp = new Vector3(0, 1f, 0);
    Vector3 temp1 = new Vector3(0, 0.5f, 0);
    Vector3 temp2;
    Vector3 temp3;
    public Transform pos1, pos2;
    private BossPatrol bossScript;
    private BossLevitatePower bossScript1;
    //public var material: playerMaterial;
    //public Collider2D col; 


    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        nextPos = starPos.position;
        bossScript = GameObject.Find("Boss1").GetComponent<BossPatrol>();
        bossScript1 = GameObject.Find("Boss1").GetComponent<BossLevitatePower>();
    }

    // Update is called once per frame
    void Update()
    {
        
       
        if (isLevitated == true)
        {
            //Debug.Log(nextPos);
            //col.material.bounciness = 0.2;
            anim.SetTrigger("isHurt");
            playerRigidbody.isKinematic = true;
            if (canMovee == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

            }
            if(this.transform.position == nextPos)
            {
                nextPos = pos1.position;
                //Vector3 temp2 = nextPos;
            }
            
            
            if (this.transform.position == pos1.position)
            {
                canMovee = false;
                nextPos = pos2.position;
                temp3 = nextPos;
                timer -= 1 * Time.deltaTime;
                if (timer <= 0f)
                {
                    canMovee = true;
                    timer = 1f;
                }

            }
            if (transform.position == pos2.position)
            {
               
                playerRigidbody.isKinematic = false;
                playerRigidbody.AddForce(Vector2.down * 30f, ForceMode2D.Impulse);
                //playerRigidbody.AddForce(Vector2.left * 10000f, ForceMode2D.Impulse);
                //playerRigidbody.velocity = new Vector2(1000, 0);
                anim.SetTrigger("isHurt");
                GetComponent<Player>().enabled = true;
                isLevitated = false;
                bossScript.canMove = true;
                bossScript1.playAnim = false;
                //col.bounciness = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "TestLevitate")
        {
            isLevitated = true;
            GetComponent<Player>().enabled = false;
            bossScript.canMove = false;
            bossScript1.playAnim = true;

        }
    }

}
