using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : PoolObject
{
   [SerializeField] private BrickBody _body;

    public Color BodyColor => _body.CurrentColor;
    public override void SetActive()
    {
        base.SetActive();
    }

    public void Initialize(Color color)
    {
        _body.Initialize(color);
    }

}
