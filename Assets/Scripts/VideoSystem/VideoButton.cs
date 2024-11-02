using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoButton : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, transform.lossyScale);
    }

    private bool _hovered = false;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cursor") && other.transform.root == transform.root)
        {
            _hovered = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cursor") && other.transform.root == transform.root)
        {
            _hovered = false;
        }
    }

    private void Update()
    {
        if(_hovered && Input.GetMouseButtonDown(0))
            Destroy(gameObject);

    }
    
}
