using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinImage : MonoBehaviour
{
    private Vector3 _startPos;
    private Vector3 _middlePos;
    private Vector3 _targetPos;
    private Vector3 _defaultPos;
    public void SetActive()
    {
        _defaultPos = transform.localPosition;
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        transform.localPosition = _defaultPos;
        gameObject.SetActive(false);
    }

    public void SetMovePosition(Vector3 newPos)
    {
        SetActive();

        _targetPos = newPos + (Vector3.right * .25f);
        _startPos = _defaultPos;
        _middlePos = _startPos + (Vector3.left * 350f);
    }

}
