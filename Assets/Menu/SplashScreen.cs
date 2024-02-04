using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SplashScreen : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string mainSceneName = "Game";
    public AudioSource splashScreenMusic;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the video player is set to play on awake and loop is off
        videoPlayer.playOnAwake = false;
        videoPlayer.isLooping = false;

        // Subscribe to the loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;

        // Start playing the video
        videoPlayer.Play();
        splashScreenMusic.Play();
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // Load the main game scene when the video ends
        SceneManager.LoadScene(mainSceneName);
    }
}
