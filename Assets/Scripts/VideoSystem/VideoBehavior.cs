using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using VideoSystem;

public class VideoBehavior : MonoBehaviour
{
    private VideoPlayer _player;
    private VideoMarkerListener _videoMarkerListener;
    private Animation _animationComponent;
    private void Awake()
    {
        _player = GetComponent<VideoPlayer>();
        _videoMarkerListener = GetComponent<VideoMarkerListener>();
        _animationComponent = GetComponent<Animation>();
        
    }

    private void Start() 
    {
        _videoMarkerListener.Subscribe(VideoEventTypes.Pause, PauseVideo);
    }

    public void PlayVideo(VideoClip clip)
    {
        
    }


    private void PauseVideo(VideoMarkerData data)
    {
        Debug.Log("pause");
        _player.Pause();
        _animationComponent.Stop();
    }
    
    
}
