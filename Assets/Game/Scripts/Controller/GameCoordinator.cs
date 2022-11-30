using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoordinator : Controller
{
    [SerializeField] private Border _border;
    [SerializeField] private Breaker _breaker;
    [SerializeField] private Ball _ball;
    [SerializeField] private ScreenSizeHelper _screenSizeHelper;
    private InputHandler _inputHandler;

    private bool _canListen;

    #region Core
    public override void Initialize(GameManager gameManager)
    {
        _inputHandler = new InputHandler();
        _screenSizeHelper.Initialize();
        _border.Initialize();
    }

    public override void Reload()
    {
    }

    public override void StartGame()
    {
        _ball.StartGame();
        ListenInputs();
    }
    public override void GameFail()
    {
        StopListenInputs();
    }

    public override void GameSuccess()
    {
        StopListenInputs();
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
