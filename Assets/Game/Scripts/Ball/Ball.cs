using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Action<Brick> OnHitBrick;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;


    private Vector3 _defaultPosition;
    public void Initialize()
    {
        _defaultPosition = transform.position;
    }
    public void StartGame()
    {
        SetVelocity((Vector3.right + Vector3.forward) * _speed);
    }

    public void Reload()
    {
        transform.position = _defaultPosition;
        SetVelocity(Vector3.zero);
    }

    private void SetVelocity(Vector3 velocity)
    {
        _rigidbody.velocity = velocity;
    }

    #region Trigger Behaviour

    public void TriggerEnterBehaviour(Collider other)
    {
        if (other.CompareTag("Brick"))
        {
            Brick brick = other.GetComponentInParent<Brick>();

            OnHitBrick?.Invoke(brick);
        }


        if (other.CompareTag("LoseBorder"))
        {
            SetVelocity(Vector3.zero);
            GameManager.Instance.GameFail();
        }
    }

    #endregion
}
