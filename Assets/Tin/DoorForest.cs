using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorForest : MonoBehaviour
{
    public void OpenForestDoor()
    {
        StartCoroutine(Forest());
    }

    IEnumerator Forest()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("FinalForestScene");
    }
}
