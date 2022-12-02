using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using Random = UnityEngine.Random;

public class SpinWheel : MonoBehaviour
{
    [SerializeField] private Transform _rotateTransform;
    [SerializeField] private Transform _awardPanel;
    [SerializeField] private Text _earnedAwardTxt;
    [SerializeField] private List<Text> _awardTexts;
    [SerializeField] private int _minAwardAmount;
    [SerializeField] private int _maxAwardAmount;

    private Text _awardTxt;
    public void Initialize()
    {
        InitializeAwards();
    }
    public void SetActiveAnimation()
    {
        gameObject.SetActive(true);
        transform.DOScale(Vector3.one * 1.2f, .25f)
                           .OnComplete(() => transform.DOScale(Vector3.one, .25f));
    }

    public void Spin()
    {

        _rotateTransform.DORotate(Vector3.forward * 360 * Random.Range(3.1f, 6.9f), 3f, RotateMode.FastBeyond360)
                        .OnComplete
                        (() =>
                        {
                            CheckAward();
                            _earnedAwardTxt.text = _awardTxt.text;
                            AwardPanel();
                        });
    }

    private void AwardPanel()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_awardPanel.DOScale(Vector3.one, .25f))
                .Append(_awardPanel.DOScale(Vector3.zero, .2f).SetDelay(1f))
                .OnComplete
                   (() =>
                    gameObject.SetActive(false)
                   );
    }
    private void InitializeAwards()
    {
        _awardTexts.ForEach(text => text.text = "$" + Random.Range(_minAwardAmount, _maxAwardAmount));
    }

    private void CheckAward()
    {
        float heighestYAxis = 0;

        for (int i = 0; i < _awardTexts.Count; i++)
        {
            if (heighestYAxis < _awardTexts[i].transform.position.y)
            {
                heighestYAxis = _awardTexts[i].transform.position.y;
                _awardTxt = _awardTexts[i];
            }

        }
    }





}
