using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public RenderTexture targetTexture;
    // Start is called before the first frame update
    void Start()
    {
        GameObject videoScreen = GameObject.Find("VIDEO");

        var videoPlayer = videoScreen.AddComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.targetTexture = targetTexture;
        videoPlayer.playOnAwake = false;
        videoPlayer.url = "Assets/Video/videoplayback.mp4";

        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
