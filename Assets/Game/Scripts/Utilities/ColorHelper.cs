using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHelper : MonoBehaviour
{
    [SerializeField] private List<Color> _colors;

    private static List<Color> Colors;

    public void Initialize()
    {
        Colors = _colors;
    }

    public static Color GetColor(int index)
    {
        return Colors[index % Colors.Count];
    }

    public static Color GetRandomColor()
    {
        int index = Random.Range(0, Colors.Count);
        return Colors[index];
    }

}
