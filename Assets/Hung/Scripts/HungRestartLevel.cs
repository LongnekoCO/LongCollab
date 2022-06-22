using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HungRestartLevel : MonoBehaviour
{
    public Scene forestScene;
    private PlayerMovementScript player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.currentHealth <= 0)
        {
            Invoke("ReloadForestLevel", 2f);
        }
    }

    void ReloadForestLevel()
    {
        SceneManager.LoadScene("ForestScene");
    }
}
