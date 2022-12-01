using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level 
{
    private List<Brick> _bricks = new List<Brick>();

    public int BrickCount => _bricks.Count;
    public void Build()
    {
        GenerateBricks();
        SetBricksColors();
    }
    public void Remove()
    {
        _bricks.ForEach(obj => obj.Dismiss());
        _bricks.Clear();
    }

    private void GenerateBricks()
    {
        float startZAxisPos = ScreenSizeHelper.ScreenWidthPosition - 2f;
        float startXAxisPos = ScreenSizeHelper.ScreenHeightPosition - 2f;

        float rowsDistance = Random.Range(-2f, -1.2f);
        int rows = Random.Range(3, 10);

        for (int i = 0; i < rows; i+=2)
        {
            for (float j = -(startXAxisPos); j < startXAxisPos; j+= 2.2f)
            {
                Brick brick = PoolHandler.Instance.GetItemFromPool("Brick") as Brick;
                brick.SetPosition(new Vector3(j, 0f, (rowsDistance * i) + startZAxisPos));
                brick.SetActive();

                _bricks.Add(brick);
            }
        }
    }

    private void SetBricksColors()
    {
        int repeat = Random.Range(2, 5);
        int jumpCount = Random.Range(1, 8);
        int colorIndex = 0;
        int brickIndex = 0;

        for (int i = 0; i < _bricks.Count; i++)
        {
            if(i % repeat == 0)
                colorIndex++;

            //if ((i + jumpCount) < _bricks.Count)
            //    brickIndex = i * jumpCount;
            //else
            //    brickIndex = i;

            _bricks[i].Initialize(ColorHelper.GetColor(colorIndex));
        }
    }

}
