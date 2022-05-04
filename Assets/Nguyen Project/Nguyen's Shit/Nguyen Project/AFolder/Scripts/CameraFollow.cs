using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float yOffset = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 cameraPos = this.transform.position;

        cameraPos.x = playerPos.x;
        cameraPos.y = playerPos.y + yOffset;
        cameraPos.z = 0;

        player.transform.position = playerPos;
        this.transform.position = cameraPos;


    }
}
