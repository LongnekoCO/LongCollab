using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevitatePower : MonoBehaviour
{
    public bool startTimer = false;
    public float timer = 5f;
    public GameObject levitateBox;
    public bool deactivate = false;
    private Animator anim;
    public bool playAnim;
     

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(deactivate == true)
        {
            startTimer = true;
            levitateBox.SetActive(false);
        }

        if (startTimer == true)
        {
            timer -= 1 * Time.deltaTime;
            if (timer <= 0)
            {
                startTimer = false;
                deactivate = false;
                levitateBox.SetActive(true);
                timer = 5f;
            }
        }

        
    }

    void Play()
    {
        if (playAnim == true)
        {
            StartCoroutine(PlayAnimation());
        }
    }

    IEnumerator PlayAnimation()
    {
        anim.SetTrigger("LevitateRaiseHand");
        yield return new WaitForSeconds(2f);
        anim.SetTrigger("LevitateDrop");
    }
}
