using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{
    public Action OnMouseButtonDown;
    public Action<Vector2> OnMouseButton;
    public Action OnMouseButtonUp;

    private Vector2 _clickPos;
    private Vector2 _currentPos;
    private Vector2 _previousPos;
    private Vector2 _deltaPos;

    private bool _isPressing;

    public void Update()
    {
        InputUpdate();
    }

    private void InputUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isPressing = true;

            _clickPos = Input.mousePosition;
            _currentPos = _clickPos;
            _previousPos = _clickPos;

            OnMouseButtonDown?.Invoke();
        }

        if (Input.GetMouseButton(0))
        {
            _currentPos = Input.mousePosition;
            _deltaPos = (_currentPos - _previousPos);

            _previousPos = _currentPos;

            OnMouseButton?.Invoke(_deltaPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isPressing = false;
            _deltaPos = Vector3.zero;
            OnMouseButtonUp?.Invoke();
        }
    }
}
