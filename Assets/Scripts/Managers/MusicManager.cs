using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _insanityMusic;

    [SerializeField]
    private float _maxInsanityVol = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float targ = (float)SanityManager._level / (float)SanityManager.InsanityLevel.NUM;

        _insanityMusic.volume = Mathf.Lerp(_insanityMusic.volume, Mathf.Lerp(0, _maxInsanityVol, targ), Time.deltaTime);
    }
}
