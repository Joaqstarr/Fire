using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourceManager : MonoBehaviour
{

    public float _amount;

    [SerializeField] float _maxAmount;
    [SerializeField] AnimationCurve _curve;

    [SerializeField]
    private CanvasGroup _canvasGroup;
    [SerializeField]
    private AudioSource _audioSource;

    public UnityEvent _onMaxed;

    private bool _isStarted = false;
    private void Start()
    {
        GameManager.Instance.OnFireStarted += StartTick;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnFireStarted -= StartTick;
    }

    private void StartTick()
    {
        _isStarted = true;
    }
    public float GetRealInterp()
    {
        return Mathf.Clamp01(_amount/_maxAmount);
    }
    public void ResetToZero()
    {
        _amount = 0;
    }

    public void ResetIfFire()
    {
        if (GameManager.Instance != null && GameManager.Instance.GetFireTime() > 0)
        {
            ResetToZero();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(!_isStarted)return;
        _amount += Time.deltaTime;
        float interp = _curve.Evaluate(_amount / _maxAmount);
        if(_audioSource != null)
            _audioSource.volume = interp;
        _canvasGroup.alpha = interp;

        if(_amount >= _maxAmount)
        {
            _onMaxed?.Invoke();
        }
    }
}
