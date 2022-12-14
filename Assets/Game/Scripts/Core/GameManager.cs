using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private DataManager _dataManager;
    [SerializeField] private PoolManager _poolManager;

    [Header("Controllers")]
    [SerializeField] private List<Controller> _controllers;

    [Header("Helpers")]
    [SerializeField] private ScreenSizeHelper _screenSizeHelper;
    [SerializeField] private ColorHelper _colorHelper;

    private static GameManager _gameManager;
    public static GameManager Instance
    {
        get
        {
            if (_gameManager == null)
            {

            }

            return _gameManager;
        }
    }

    public LevelController LevelController => _controllers[0].GetComponent<LevelController>();

    #region Init
    private void Awake()
    {
        _gameManager = this;
    }
    private void Start()
    {
        Initialize();
    }
    #endregion

    #region States
    public void Initialize()
    {
        _dataManager.Initialize();
        _poolManager.Initialize();

        _screenSizeHelper.Initialize();
        _colorHelper.Initialize();

        _controllers.ForEach(controller => controller.Initialize(this));

    }

    public void StartGame()
    {
        _controllers.ForEach(controller => controller.StartGame());
    }

    public void Reload()
    {
        _controllers.ForEach(controller => controller.Reload());
    }
    public void GameSuccess()
    {
        PlayerHelper.Instance.UpdateLevel(1);
        PlayerHelper.Instance.UpdateCoin(ScoreSystem.GetCurrentScore());
        _controllers.ForEach(controller => controller.GameSuccess());
        
        GameOver();
    }
    public void GameFail()
    {
        _controllers.ForEach(controller => controller.GameFail());

        GameOver();
    }
    public void GameOver()
    {
    }
    #endregion

    public void GameQuit()
    {
        Application.Quit();
    }
}
