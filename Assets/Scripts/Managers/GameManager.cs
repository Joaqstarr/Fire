using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VideoSystem;
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{

    public delegate void FireDel();

    public FireDel OnFireStarted;

    [Range(1f, 300f)]
    [SerializeField] private float _timeAddedPerLog;
    [SerializeField] private EyeBlink _eyeBlink;
    [SerializeField] private VideoBehavior _mainMinigameBehavior;

    
    private int _amountOfLogs = 0;
    private int _amountOfAcorns = 0;
    private bool _hasStarted = false;
    [SerializeField]
    private float _fireTime = 0;

    public static GameManager Instance;

    public enum GameState
    {
        MainScreen,
        Minigame
    }

    private GameState _state;

    [SerializeField]
    private CanvasGroup _mainScreenGroup;
    
    private StickFeed _stickFeed;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        
        _hasStarted = false;
    }

    void Start()
    {
        _stickFeed = GetComponentInChildren<StickFeed>();
        _mainMinigameBehavior.GetComponent<VideoMarkerListener>().Subscribe(VideoEventTypes.EndVideo, EndMainMinigame);

  
    }

    // Update is called once per frame
    void Update()
    {
        _fireTime = Mathf.Max(0, _fireTime - Time.deltaTime);
        UnityEngine.Cursor.visible = false;

    }


    public void AddLogs(int amt)
    {
        _amountOfLogs += amt;

    }
    
    public void AddAcorns(int amt)
    {
        _amountOfAcorns += amt;

    }

    public void SendLogToFire()
    {
        if(_amountOfLogs <= 0)return;

        _amountOfLogs--;
        _fireTime += _timeAddedPerLog;
        _stickFeed.ThrowStick();
        
        if (!_hasStarted)
        {
            _hasStarted = true;
            
            OnFireStarted?.Invoke();
        }

    }

    public void PickUpSticksGame()
    {
        EnterMinigame("PickUpSticks", () =>
        {
            AddLogs(3);
        });
    }
    public void AcornGame()
    {
        EnterMinigame("Acorn", () =>
        {
            AddAcorns(5);
        });
    }

    public void EnterMinigame(string name, Action onTransition)
    {
        _state = GameState.Minigame;

        EyeBlink.OnEyeTransition += BlinkTransition;
        _eyeBlink.BlinkEye();

        void BlinkTransition()
        {
            EyeBlink.OnEyeTransition -= BlinkTransition;
            DisableMainScreen();

            _mainMinigameBehavior.PlayVideo(name);
            onTransition();
        }
    }

    private void DisableMainScreen()
    {
        _mainScreenGroup.alpha = 0;
        _mainScreenGroup.blocksRaycasts = false;
        _mainScreenGroup.interactable = false;
    }

    private void EnableMainScreen()
    {
        _mainScreenGroup.alpha = 1;
        _mainScreenGroup.blocksRaycasts = true;
        _mainScreenGroup.interactable = true;
    }

    private void EndMainMinigame(VideoMarkerData data)
    {
        _state = GameState.MainScreen;

        EyeBlink.OnEyeTransition += BlinkTransition;
        _eyeBlink.BlinkEye();

        void BlinkTransition()
        {
            EyeBlink.OnEyeTransition -= BlinkTransition;
            EnableMainScreen();
        }
        
    }

    public float GetFireTime()
    {
        return _fireTime;
    }
}

