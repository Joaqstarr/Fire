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

    public UnityEvent _onMaxed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ResetToZero()
    {
        _amount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _amount += Time.deltaTime;
        _canvasGroup.alpha = _curve.Evaluate(_amount/_maxAmount);

        if(_amount >= _maxAmount)
        {
            _onMaxed?.Invoke();
        }
    }
}
