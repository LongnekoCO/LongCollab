using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThorLightning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LightningEnd());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LightningEnd()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
