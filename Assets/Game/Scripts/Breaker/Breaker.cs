using GameCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private MovementSettings _movementSettings;
    public void MoveXAxis(Vector2 inputPos)
    {
        Vector3 currentPos = transform.position;
        currentPos += inputPos.x * Time.deltaTime * _movementSettings.HorizontalSpeed * Vector3.right;
        currentPos.x = Mathf.Clamp(currentPos.x, _movementSettings.MinX, _movementSettings.MaxX);

         _rigidbody.MovePosition(currentPos);
    }
}
