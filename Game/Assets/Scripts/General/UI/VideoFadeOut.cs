using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoFadeOut : MonoBehaviour
{
    public float fadeDuration = 1.0f; // Duration of the fade-out effect in seconds

    private VideoPlayer videoPlayer;
    private Material videoMaterial;
    private float originalAlpha;
    private float fadeStartTime;
    private bool isFadingOut;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoMaterial = GetComponent<Renderer>().material;

        originalAlpha = videoMaterial.color.a; // Get the initial alpha value

        videoPlayer.loopPointReached += FadeOutVideo;
    }

    private void FadeOutVideo(VideoPlayer source)
    {
        videoPlayer.gameObject.SetActive(false);
    }
}