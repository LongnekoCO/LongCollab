using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyOwnIAEnemy : MonoBehaviour
{
    public int enemyHealth;
    public int enemyValue;
    public float aniDelay;

    public int rutine;
    public float cronometer;
    public Animator ani;
    public int direction;

    public float speed_walk;
    public float speed_run;

    public GameObject player;

    public bool isAttack;

    public float vision_range;
    public float vision_atack;




    public void OnTriggerEnter2D(Collider2D col)
    {
        /*if (col.tag == "bullet")
        {
            enemyHealth -= Bullet.damage;

            if (enemyHealth <= 0)
            {
                ani.SetBool("die", true);
                Debug.Log(enemyValue);
                Destroy(gameObject, aniDelay);
            }

        }*/
    }


    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }


    public void behaviors()
    {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) > vision_range && !isAttack)
        {

            ani.SetBool("run", false);
            cronometer += 1 * Time.deltaTime;

                if (cronometer >= 4)
                {
                    rutine = Random.Range(0, 2);
                    cronometer = 0;
                }

                switch (rutine)
                {
                    case 0:

                        ani.SetBool("walk", false);

                    break;

                    case 1:

                        direction = Random.Range(0, 2);
                        rutine++;

                    break;

                    case 2:

                        switch (direction)
                        {
                            case 0:

                                transform.rotation = Quaternion.Euler(0, 0, 0);
                                transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                                break;

                            case 1:

                                transform.rotation = Quaternion.Euler(0, 180, 0);
                                transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                                break;
                        }

                    ani.SetBool("walk", true);
                    break;
                }
        }
    }
    //Update is called once per frame
    void Update()
    {
        behaviors();
    }

}
