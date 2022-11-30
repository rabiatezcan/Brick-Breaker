using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    public void StartGame()
    {
        _rigidbody.velocity = (Vector3.right + Vector3.forward) * _speed;
    }
}
