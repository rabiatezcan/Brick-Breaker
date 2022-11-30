using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    [SerializeField] private List<Transform> _borderTransforms;

    public void Initialize()
    {
        InitializeBordersScales();
        InitializeBordersPositions();
    }

    private void InitializeBordersScales()
    {
        for (int i = 0; i < _borderTransforms.Count; i++)
        {
            if (i < 2)
                _borderTransforms[i].localScale = new Vector3(ScreenSizeHelper.ScreenWidthValue, _borderTransforms[i].localScale.y, _borderTransforms[i].localScale.z);
            else
                _borderTransforms[i].localScale = new Vector3(ScreenSizeHelper.ScreenHeightValue, _borderTransforms[i].localScale.y, _borderTransforms[i].localScale.z);

        }
    }
    private void InitializeBordersPositions()
    {
        _borderTransforms[0].position = Vector3.forward * ScreenSizeHelper.ScreenWidthPosition;
        _borderTransforms[1].position = Vector3.forward * -ScreenSizeHelper.ScreenWidthPosition;
        _borderTransforms[2].position = Vector3.right * ScreenSizeHelper.ScreenHeightPosition;
        _borderTransforms[3].position = Vector3.right * -ScreenSizeHelper.ScreenHeightPosition;
    }
}
