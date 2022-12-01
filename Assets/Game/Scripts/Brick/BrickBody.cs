using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBody : MonoBehaviour
{
    [SerializeField] MeshRenderer _meshRenderer;
    [SerializeField] Material _material;

    private Color _currentColor;
    public Color CurrentColor => _currentColor;
    public void Initialize(Color color)
    {
        _meshRenderer.material.CopyPropertiesFromMaterial(_material);
        _meshRenderer.material.color = color;

        _currentColor = color;
    }
}
