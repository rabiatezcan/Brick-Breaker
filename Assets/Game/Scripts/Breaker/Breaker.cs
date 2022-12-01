using GameCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private MovementSettings _movementSettings;
    [SerializeField] private BreakerBody _body;

    private LevelController _levelController;
    private int _breakedBrickCount;
    public void Initialize(LevelController levelController)
    {
        _levelController = levelController; 
        _body.Initialize(ColorHelper.GetRandomColor());
    }

    public void Reload()
    {
        transform.position = new Vector3(0f, 0f, transform.position.z);
    }

    public void MoveXAxis(Vector2 inputPos)
    {
        Vector3 currentPos = transform.position;
        currentPos += inputPos.x * Time.deltaTime * _movementSettings.HorizontalSpeed * Vector3.right;
        currentPos.x = Mathf.Clamp(currentPos.x, -(ScreenSizeHelper.ScreenHeightPosition - 2f), ScreenSizeHelper.ScreenHeightPosition - 2f);

        _rigidbody.MovePosition(currentPos);
    }

    public void CheckColor(Brick brick)
    {
        if (brick.BodyColor == _body.GetCurrentColor())
        {
            brick.RemoveBrick();

            _breakedBrickCount++;

            CheckGameIsOver();
        }
        else
            _body.SetColor(brick.BodyColor);
    }

    private void CheckGameIsOver()
    {
        if(_breakedBrickCount == _levelController.CurrentLevel.BrickCount)
            GameManager.Instance.GameSuccess();
    }
}
