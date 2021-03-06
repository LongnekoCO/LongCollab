using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorFunction animatorFunction;
    [SerializeField] int thisIndex;







    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(menuButtonController.index == thisIndex)
        {
            animator.SetBool("Selected", true);
            if(Input.GetAxis ("Submit") == 1)
            {
                animator.SetBool(("Press"), true);
            }
            else if (animator.GetBool("Press"))
            {
                animator.SetBool("Press", false);
                animatorFunction.disableOnce = true;
            }
        }
        else
        {
            animator.SetBool("Selected", false);
        }
    }
}
