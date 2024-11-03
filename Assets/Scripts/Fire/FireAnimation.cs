using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FireAnimation : MonoBehaviour
{
    [FormerlySerializedAs("_image")] [SerializeField] private UnityEngine.UI.Image _fullFireImage;
    [SerializeField] private float _drainTime = 24f;

    void Update()
    {
        if (GameManager.Instance == null) return;
        
        
        float time = GameManager.Instance.GetFireTime();


        float lerp = Mathf.Clamp01(((time - 4) / _drainTime));

        Vector4 col = _fullFireImage.color;

        col.w = lerp * lerp;

        _fullFireImage.color = col;
    }
}
