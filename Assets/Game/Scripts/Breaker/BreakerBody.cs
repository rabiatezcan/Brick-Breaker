using System.Collections;
using UnityEngine;

public class BreakerBody : MonoBehaviour
{
    [SerializeField] MeshRenderer _meshRenderer;
    
    public void Initialize(Color color)
    {
        SetColor(color);    
    }

    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }

    public Color GetCurrentColor()
    {
        return _meshRenderer.material.color;
    }
}
