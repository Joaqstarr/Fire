using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonInput : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            Destroy(gameObject);
    }
}
