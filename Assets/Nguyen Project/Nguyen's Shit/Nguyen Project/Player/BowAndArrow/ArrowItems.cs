using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowItems : MonoBehaviour
{
    public GameObject arrowPrize;
    public Bow bowScript;
    public GameObject player;
    public Transform playerBow;
    public float speed = 5f;
    public Rigidbody2D rb;

    public List<GameObject> arrowPrizes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //playerBow = GameObject.FindWithTag("Bow");
        rb.velocity = transform.up * speed;
        player = GameObject.Find("Dog");
        playerBow = player.transform.Find("Bow");
        //bowScript = GetComponent<Bow>();
        int i = Random.Range(0, arrowPrizes.Count);
        arrowPrize = arrowPrizes[i];
        StartCoroutine(SelfDestruct());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            //for (int i = 0; i < playerBow.GetComponent<Bow>().arrowsSelect.Count; i++)
            //{
            //    if (playerBow.GetComponent<Bow>().arrowsSelect[i] != arrowPrize)
            //    {
            //        playerBow.GetComponent<Bow>().arrowsSelect.Add(arrowPrize);
            //        Destroy(gameObject);
            //    }

            //    else
            //    {
            //        Destroy(gameObject);
            //    }
            //}

            if(!playerBow.GetComponent<Bow>().arrowsSelect.Contains(arrowPrize))
            {
                playerBow.GetComponent<Bow>().arrowsSelect.Add(arrowPrize);
                Destroy(gameObject);
            }

            else
            {
                Destroy(gameObject);
            }


        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
