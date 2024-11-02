using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{



    [Range(1f, 300f)]
    [SerializeField] private float _timeAddedPerLog;

    private int _amountOfLogs = 0;
    private float _fireTime = 0;


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
}
