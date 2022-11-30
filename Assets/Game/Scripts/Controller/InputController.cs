using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : Controller
{
    private InputHandler _inputHandler;

    #region Core
    public override void Initialize(GameManager gameManager)
    {
        _inputHandler = new InputHandler();
    }

    public override void StartGame()
    {
        ListenInputs();
    }

    public override void Reload()
    {
    }

    public override void GameSuccess()
    {
        StopListenInputs();
    }

    public override void GameFail()
    {
        StopListenInputs();
    }
    #endregion
    private void ListenInputs()
    {
        _inputHandler.OnMouseButtonDown += Select;
        _inputHandler.OnMouseButton += Drag;
        _inputHandler.OnMouseButtonUp += Drop;
    }
    private void StopListenInputs()
    {
        _inputHandler.OnMouseButtonDown -= Select;
        _inputHandler.OnMouseButton -= Drag;
        _inputHandler.OnMouseButtonUp -= Drop;
    }

    public void Select()
    {
      
    }

    public void Drag(Vector3 inputPos)
    {
    }

    public void Drop()
    {
    }

    private void Update()
    {
        _inputHandler.Update();
    }

}
