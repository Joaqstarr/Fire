using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedToBlue : MonoBehaviour
{
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _coldColor;
    [SerializeField] private ResourceManager _resourceManager;

    Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    void Update()
    {
        Color color = Color.Lerp(_startColor, _coldColor, _resourceManager.GetRealInterp());
        _image.color = color;
    }
}
