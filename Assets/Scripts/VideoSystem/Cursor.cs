using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public int hoverNum = 0;

    Animator animator;

    [SerializeField] private SpriteRenderer _spriteRend;
    [SerializeField] private float _zPos = -1;

    [SerializeField] private Vector3 _targScale = Vector3.one;
    [SerializeField] private bool _matchWithMousePos;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        lastMouse = Input.mousePosition;
    }

    Vector2 lastMouse;
    [SerializeField]
    private float _mouseSpeed = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        Vector3 setPos = Camera.main.ScreenToWorldPoint(ClampToScreen(Input.mousePosition));
        setPos.z = _zPos;
        if (!_matchWithMousePos)
        {

            Vector2 boundSize = _spriteRend.size;
            Vector3 newCursorPos = (boundSize * GetMousePosition()) - (boundSize / 2);


           // newCursorPos = (Vector2)_rb.position + (MouseDelta() * _mouseSpeed);

            newCursorPos.z = _zPos;
            setPos = transform.parent.TransformPoint(newCursorPos);
            /*
            setPos = (Vector2)_rb.position + (MouseDelta() * _mouseSpeed);

            
            Vector2 localSetPos = transform.InverseTransformPoint(setPos);

            float widthUnits = boundSize.x / _spriteRend.sprite.pixelsPerUnit;
            float heightUnits = boundSize.y / _spriteRend.sprite.pixelsPerUnit;

            localSetPos.x = Mathf.Clamp(localSetPos.x, -widthUnits/2, widthUnits/2);
            localSetPos.y = Mathf.Clamp(localSetPos.y, -heightUnits / 2, heightUnits / 2);

            setPos = transform.TransformPoint(localSetPos);
            */
        }

        _rb.MovePosition(setPos);


        Vector3 parentScale = transform.parent.lossyScale;
        transform.localScale = new Vector3(_targScale.x/parentScale.x, _targScale.y/parentScale.y, _targScale.z/parentScale.z);




        animator.SetBool("hover", hoverNum != 0);

        lastMouse = Input.mousePosition;

    }

    private Vector2 MouseDelta()
    {
        return (Vector2)Input.mousePosition - lastMouse;
    }

    private Vector2 ClampToScreen(Vector2 vec)
    {
        Vector2 outVec = Vector2.zero;

        outVec.x = Mathf.Clamp(vec.x, 0, Screen.width);
        outVec.y = Mathf.Clamp(vec.y, 0, Screen.height);

        return outVec;

    }
    private Vector2 GetMousePosition()
    {
        Vector2 pos = Input.mousePosition;
        pos /= new Vector2(Screen.width, Screen.height);

        return new Vector2(Mathf.Clamp01(pos.x), Mathf.Clamp01(pos.y));
    }
    
    
}
