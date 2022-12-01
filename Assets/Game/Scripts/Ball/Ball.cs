using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Action<Brick> OnHitBrick;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    
    public void StartGame()
    {
        _rigidbody.velocity = (Vector3.right + Vector3.forward) * _speed;
    }


    #region Trigger Behaviour
    
    public void TriggerEnterBehaviour(Collider other)
    {
        if (other.CompareTag("Brick"))
        {
            Brick brick = other.GetComponentInParent<Brick>();

            OnHitBrick?.Invoke(brick);
        }
    }

    #endregion
}
