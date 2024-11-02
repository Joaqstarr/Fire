using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoButton : MonoBehaviour
{
    int hoverNumber = 0;
    SpriteRenderer spriteRenderer;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, transform.lossyScale);
    }

    private bool _hovered = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cursor") && other.transform.root == transform.root)
        {
            _hovered = true;
            spriteRenderer.enabled = true;
            other.GetComponent<Cursor>().hoverNum++;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cursor") && other.transform.root == transform.root)
        {
            _hovered = false;
            spriteRenderer.enabled = false;
            other.GetComponent<Cursor>().hoverNum--;
        }
    }

    private void Update()
    {
        if(_hovered && Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
           
        
   

    }
    
}
