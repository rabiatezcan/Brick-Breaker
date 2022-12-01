using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : PoolObject
{
   [SerializeField] private BrickBody _body;
   [SerializeField] private ParticleSystem _removeFX;

    public Color BodyColor => _body.CurrentColor;
    public override void SetActive()
    {
        base.SetActive();
    }

    public void Initialize(Color color)
    {
        _body.Initialize(color);
    }

    public void RemoveBrick()
    {
        _removeFX.Play();

        StartCoroutine(DismissDelay(_removeFX.startLifetime));
    }

    public IEnumerator DismissDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Dismiss();
    }
}
