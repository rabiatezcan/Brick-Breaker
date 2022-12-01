using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoordinator : Controller
{
    [SerializeField] private Border _border;
    [SerializeField] private Breaker _breaker;
    [SerializeField] private Ball _ball;
  
    private InputHandler _inputHandler;

    private bool _canListen;

    #region Core
    public override void Initialize(GameManager gameManager)
    {
        _inputHandler = new InputHandler();
        _border.Initialize();
        _breaker.Initialize(gameManager.LevelController);
        _ball.Initialize();
    }

    public override void Reload()
    {
        _ball.Reload();
        _breaker.Reload();
    }

    public override void StartGame()
    {
        _ball.StartGame();
        ListenInputs();
        _ball.OnHitBrick += _breaker.CheckColor;
    }
    public override void GameFail()
    {
        StopListenInputs();
        _ball.OnHitBrick -= _breaker.CheckColor;

    }

    public override void GameSuccess()
    {
        StopListenInputs();
        _ball.OnHitBrick -= _breaker.CheckColor;
    }

    #endregion

    private void ListenInputs()
    {
        _canListen = true;

        _inputHandler.OnMouseButton += _breaker.MoveXAxis;
    }
    private void StopListenInputs()
    {
        _canListen = false;

        _inputHandler.OnMouseButton -= _breaker.MoveXAxis;
    }

    private void Update()
    {
        if (_canListen)
            _inputHandler.Update();
    }


}
