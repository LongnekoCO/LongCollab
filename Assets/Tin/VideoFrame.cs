using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class VideoFrame : MonoBehaviour
{
    public VideoPlayer splashScreen;

    // Start is called before the first frame update
    void Start()
    {
        
        splashScreen.waitForFirstFrame = true;
        splashScreen.playOnAwake = true;
    }

    // Update is called once per frame
    
}
