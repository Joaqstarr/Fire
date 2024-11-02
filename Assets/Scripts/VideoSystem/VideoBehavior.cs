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
    private Animator _animationComponent;

    private VideoMarkerData.InputType _acceptingInputType;

    [SerializeField] private Transform _buttonHolder;

    [SerializeField] private VideoButton _buttonPrefab;
    [SerializeField] private ActionButtonInput _actionButtonPrefab;

    private void Awake()
    {
        _player = GetComponent<VideoPlayer>();
        _videoMarkerListener = GetComponent<VideoMarkerListener>();
        _animationComponent = GetComponent<Animator>();
        
    }


    private void Start()
    {
        _videoMarkerListener.Subscribe(VideoEventTypes.Pause, PauseVideo);
        _videoMarkerListener.Subscribe(VideoEventTypes.AcceptInput, StartAcceptingInput);
        _videoMarkerListener.Subscribe(VideoEventTypes.StopAcceptingInput, StopAcceptingInput);
    }

    private void OnDisable()
    {
        _videoMarkerListener.Unsubscribe(VideoEventTypes.Pause, PauseVideo);
        _videoMarkerListener.Unsubscribe(VideoEventTypes.AcceptInput, StartAcceptingInput);
        _videoMarkerListener.Unsubscribe(VideoEventTypes.StopAcceptingInput, StopAcceptingInput);
    }

    private void Update()
    {
        if (_acceptingInputType > VideoMarkerData.InputType.None && _buttonHolder.childCount == 0)
        {
            Resume();
        }
    }

    public void Resume()
    {
        _animationComponent.speed = 1;

    }

    public void PlayVideo(VideoClip clip)
    {
        
    }


    private void PauseVideo(VideoMarkerData data)
    {
        _animationComponent.speed = 0;

    }

    private void StartAcceptingInput(VideoMarkerData data)
    {
        _acceptingInputType = (VideoMarkerData.InputType)Mathf.Max((int)_acceptingInputType, (int)data.InputStyle);

        if (_acceptingInputType == VideoMarkerData.InputType.ActionButton)
        {
            Instantiate(_actionButtonPrefab, _buttonHolder);
        }
        
        if (_acceptingInputType == VideoMarkerData.InputType.ClickButton)
        {
            //spawn Buttons
            for (int i = 0; i < data.Buttons.Length; i++)
            {
                VideoButton newButton = Instantiate(_buttonPrefab, _buttonHolder);
                newButton.transform.localPosition = data.Buttons[i].Pos;
                Vector3 scale = data.Buttons[i].Size;
                scale.z = 3;
                newButton.transform.localScale = scale;
            }
        }
        
    }
    
    private void StopAcceptingInput(VideoMarkerData data)
    {
        _acceptingInputType = VideoMarkerData.InputType.None;
    }
    
}
