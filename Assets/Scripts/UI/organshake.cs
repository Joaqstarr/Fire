using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class organshake : MonoBehaviour
{
    [SerializeField]bool isShaking=false;
    [SerializeField]private int shaketime = 5;
    [SerializeField]private float shakestrength = 1;
    [SerializeField]private int vabrado = 2;



    public void StartShake()
    {
        isShaking = true;
    }

    public void StopShake()
    {
        isShaking = false; 
    }

    IEnumerator ShakeLoop()
    {
        while (true)
        {
            if (isShaking)
            {


                transform.DOShakePosition(shaketime, shakestrength, vabrado, 80, false, true);
            }
            yield return new WaitForSeconds(shaketime);
        }
    }





    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShakeLoop());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
