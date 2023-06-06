using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoLooper : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += LoopVideo;
    }

    private void LoopVideo(VideoPlayer source)
    {
        source.frame = 0; // Reset the frame to the beginning
        source.Play();    // Start playing again
    }
}
