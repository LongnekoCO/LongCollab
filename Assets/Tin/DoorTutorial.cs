using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorTutorial : MonoBehaviour
{
    



    public void OpenTutorialDoor()
    {
        StartCoroutine(Tutorial());
    }
 
    IEnumerator Tutorial()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("TutorialScene");
    }

}
