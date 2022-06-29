using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorIce : MonoBehaviour
{
    public void OpenIceDoor()
    {
        StartCoroutine(Ice());
    }

    IEnumerator Ice()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("FinalIceScene");
    }
}
