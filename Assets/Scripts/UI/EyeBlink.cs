using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBlink : MonoBehaviour
{

    public delegate void EyeDel();

    public static EyeDel OnEyeTransition;

    private Animator _anim;
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void BlinkEye()
    {
        _anim.SetTrigger("Blink");
    }

    public void TransitionEye()
    {
        OnEyeTransition?.Invoke();
    }
}
