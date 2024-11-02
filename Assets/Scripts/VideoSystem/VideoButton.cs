using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoButton : MonoBehaviour
{
    int hoverNumber = 0;
    SpriteRenderer spriteRenderer;
    Cursor _cursor;
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

            if (_cursor == null)
                _cursor = other.GetComponent<Cursor>();

            _cursor.hoverNum++;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cursor") && other.transform.root == transform.root)
        {
            _hovered = false;
            spriteRenderer.enabled = false;
            _cursor.hoverNum--;
        }
    }

    private void OnDisable()
    {
        if (_hovered)
        {
            _hovered = false ;
            _cursor.hoverNum--;
        }
    }

    private void Update()
    {
        if(_hovered && Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
           

    }
    

    public void SetSprite(Sprite sprite, bool randomizeRot)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = sprite;
        spriteRenderer.color = Color.white;


        if (randomizeRot)
        {
            Vector3 euler = transform.localEulerAngles;
            euler.z += UnityEngine.Random.Range(-120, 120);
            transform.localEulerAngles = euler;
        }
    }
}
