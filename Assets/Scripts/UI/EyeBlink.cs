using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBlink : MonoBehaviour
{

    public delegate void EyeDel();

    public static EyeDel OnEyeTransition;


    public void TransitionEye()
    {
        OnEyeTransition?.Invoke();
    }
}
