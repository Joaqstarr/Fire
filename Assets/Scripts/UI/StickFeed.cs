using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickFeed : MonoBehaviour
{
    private bool _throwingStick = false;
    [SerializeField] private RectTransform _stick;


    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private Vector2 _endPosition;

    [SerializeField]
    private float _tweenTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        _stick.anchoredPosition3D = _startPosition;

        _stick = transform.GetChild(0).GetComponent<RectTransform>();
    }

    
    public void ThrowStick()
    {
        _stick.DOKill();
        _stick.anchoredPosition3D = _startPosition;
        _stick.localScale = Vector3.one;
        _stick.eulerAngles = Vector3.zero;
        _stick.DOLocalMove(_endPosition, _tweenTime);
        _stick.DOScale(0, _tweenTime);
        _stick.DORotate(new Vector3(0,0,600), _tweenTime);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.TransformPoint(_startPosition), transform.TransformPoint(_endPosition) );
    }
}
