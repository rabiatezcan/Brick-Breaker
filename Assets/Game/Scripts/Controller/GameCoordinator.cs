using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoordinator : Controller
{
    [SerializeField] private Breaker _breaker;
    private InputHandler _inputHandler;

    private bool _canListen;

    #region Core
    public override void Initialize(GameManager gameManager)
    {
        _inputHandler = new InputHandler();
    }

    public override void Reload()
    {
    }

    public override void StartGame()
    {
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
