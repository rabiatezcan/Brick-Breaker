using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : Controller
{
    private Level _level;
    public Level CurrentLevel => _level;

    #region States
    public override void Initialize(GameManager gameManager)
    {
        _level = new Level();
        LoadLevel();
    }
    public override void StartGame()
    {
    }
    public override void Reload()
    {
        UnloadLevel();
        LoadLevel();
    }
    public override void GameFail()
    {
    }

    public override void GameSuccess()
    {
        Reload();
    }
    #endregion

    private void LoadLevel()
    {
        _level.Build();
    }

    private void UnloadLevel()
    {
        _level.Remove();
    }
}
