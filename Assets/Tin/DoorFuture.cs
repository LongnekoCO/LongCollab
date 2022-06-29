using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorFuture : MonoBehaviour
{
    public void OpenFutureDoor()
    {
        StartCoroutine(Future());
    }

    IEnumerator Future()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("FinalFutureScene");
    }
}
