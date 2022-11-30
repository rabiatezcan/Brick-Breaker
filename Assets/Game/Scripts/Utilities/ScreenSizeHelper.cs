using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSizeHelper : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private static Camera Camera;
    private static Vector3 WorldPosition;
    private static float _widthMultiplier = 2f;

    public void Initialize()
    {
        Camera = _camera;
        WorldPosition = _camera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    public static float ScreenWidthValue => WorldPosition.x * _widthMultiplier;
    public static float ScreenHeightValue => WorldPosition.y;

    public static float ScreenWidthPosition => Camera.orthographicSize;
    public static float ScreenHeightPosition => Camera.aspect * ScreenWidthPosition;

}