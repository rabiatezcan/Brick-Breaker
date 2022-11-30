using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : Screen
{
    [SerializeField] private LevelView _levelView;

    public override void Show()
    {
        base.Show();
        _levelView.SetLevelText();
    }

    public override void Hide()
    {

        base.Hide();
    }
}
