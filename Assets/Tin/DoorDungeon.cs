using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorDungeon : MonoBehaviour
{
    public void OpenDungeonDoor()
    {
        StartCoroutine(Dungeon());
    }

    IEnumerator Dungeon()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("FinalDungeonScene");
    }
}
