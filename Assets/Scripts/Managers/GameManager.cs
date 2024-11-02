using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{



    [Range(1f, 300f)]
    [SerializeField] private float _timeAddedPerLog;
    [SerializeField] private EyeBlink _eyeBlink;

    private int _amountOfLogs = 0;
    private float _fireTime = 0;
    

    public enum GameState
    {
        MainScreen,
        Minigame
    }

    private GameState _state;

    [SerializeField]
    private CanvasGroup _mainScreenGroup; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _fireTime = Mathf.Max(0, _fireTime - Time.deltaTime);

    }


    public void AddLogs(int amt)
    {
        _amountOfLogs += amt;
        
    }

    public bool SendLogToFire()
    {
        if(_amountOfLogs <= 0)return false;

        _amountOfLogs--;
        return true;
    }

    public void EnterMinigame()
    {
        _state = GameState.Minigame;

        EyeBlink.OnEyeTransition += BlinkTransition;
        _eyeBlink.BlinkEye();

        void BlinkTransition()
        {
            EyeBlink.OnEyeTransition -= BlinkTransition;
            DisableMainScreen();
        }
    }

    private void DisableMainScreen()
    {
        _mainScreenGroup.alpha = 0;
        _mainScreenGroup.blocksRaycasts = false;
        _mainScreenGroup.interactable = false;
    }
}