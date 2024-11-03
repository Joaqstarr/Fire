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
    }

    // Update is called once per frame
    void Update()
    {
        
        
        Vector3 setPos = Camera.main.ScreenToWorldPoint(ClampToScreen(Input.mousePosition));
        setPos.z = _zPos;
        if (!_matchWithMousePos)
        {

            Vector2 boundSize = _spriteRend.size;
            Vector3 newCursorPos = (boundSize * GetMousePosition()) - (boundSize / 2);
            newCursorPos.z = _zPos;
            setPos = transform.parent.TransformPoint(newCursorPos);

        }
        
        _rb.MovePosition(setPos);


        Vector3 parentScale = transform.parent.lossyScale;
        transform.localScale = new Vector3(_targScale.x/parentScale.x, _targScale.y/parentScale.y, _targScale.z/parentScale.z);



        animator.SetBool("hover", hoverNum != 0);
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
