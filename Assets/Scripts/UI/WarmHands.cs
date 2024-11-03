using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmHands : MonoBehaviour
{

    [SerializeField] Vector2 _hidePos;
    [SerializeField] Vector2 _showPos;
    [SerializeField] float _tweenTime = 2;
    [SerializeField] float _showDuration = 5;


    private bool _showing = false;
    public void ActivateWarmHands()
    {
        if (_showing) return;

        _showing = true;

        transform.DOLocalMove(_showPos, _tweenTime).SetEase(Ease.OutBack).onComplete += ()=> { 
            StartCoroutine(WaitWhileShowing());
        };

        IEnumerator WaitWhileShowing()
        {
            yield return new WaitForSeconds(_showDuration);
            transform.DOLocalMove(_hidePos, _tweenTime).SetEase(Ease.InBack).onComplete += () => {
                _showing = false;
            };
        }
    }
}
