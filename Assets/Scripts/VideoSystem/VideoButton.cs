using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoButton : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, transform.lossyScale);
    }
    
    public void OnMouseDown()
    {
        Destroy(gameObject);
        
    }
}
