using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MainScreen : Screen
{
    [SerializeField] private SpinWheel _spinWheel;

    public override void Show()
    {
        _spinWheel.Initialize();
        base.Show();
    }

    public void SetActiveSpinWheel()
    {
        _spinWheel.SetActiveAnimation();
    }
}
