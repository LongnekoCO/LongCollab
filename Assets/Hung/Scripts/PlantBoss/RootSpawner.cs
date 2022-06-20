using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootSpawner : MonoBehaviour
{
    public GameObject root;
    public GameObject warningSign;
    public float timeStart;
    public float timeDelay;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RootSpawning", timeStart, timeDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RootSpawning()
    {
        Instantiate(warningSign, this.transform.position, Quaternion.identity);
        StartCoroutine(RootSpawningRoutine());
    }

    IEnumerator RootSpawningRoutine()
    {
        Instantiate(warningSign, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2.5f);
        GameObject root1 = Instantiate(root, this.transform.position, Quaternion.identity);
        Destroy(root1, 4f);
    }
}
