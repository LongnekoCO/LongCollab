using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungButtonManager : MonoBehaviour
{
    public GameObject[] arrow;
    public int arrowSelected;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftButton()
    {
        arrow[arrowSelected].SetActive(false);
        arrowSelected--;
        if (arrowSelected < 0)
        {
            arrowSelected += arrow.Length;
        }
        arrow[arrowSelected].SetActive(true);
    }

    public void RightButton()
    {
        arrow[arrowSelected].SetActive(false);
        arrowSelected = (arrowSelected + 1) % arrow.Length;
        arrow[arrowSelected].SetActive(true);
    }
}
