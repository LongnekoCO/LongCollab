using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour
{
    public bool enterAllowed;
    public string sceneToLoad;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DoorTutorial>())
        {
            enterAllowed = true;
            sceneToLoad = "TutorialScene";
            Debug.Log("Tutorial");

        }
        else if (collision.GetComponent<DoorForest>())
        {
            enterAllowed = true;
            sceneToLoad = "ForestScene";

        }
        else if (collision.GetComponent<DoorIce>())
        {
            enterAllowed = true;
            sceneToLoad = "IceScene";

        }
        else if (collision.GetComponent<DoorFuture>())
        {
            enterAllowed = true;
            sceneToLoad = "FutureScene";

        }
        else if (collision.GetComponent<DoorDungeon>())
        {
            enterAllowed = true;
            sceneToLoad = "DungeonScene";

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<DoorTutorial>()|| collision.GetComponent<DoorForest>()|| collision.GetComponent<DoorIce>()|| collision.GetComponent<DoorFuture>()|| collision.GetComponent<DoorDungeon>())
        {
            enterAllowed = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(enterAllowed && Input.GetKey(KeyCode.F))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
