using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using DG.Tweening;

public class UIPoints : MonoBehaviour
{
    int displayedPoints = 0;
    public TextMeshProUGUI pointsLabel;
    public RectTransform icon;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnPointsUpdated.AddListener(UpdatePoints);
        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnPointsUpdated.RemoveListener(UpdatePoints);
        GameManager.Instance.OnGameStateUpdated.RemoveListener(GameStateUpdated);
    }

    private void GameStateUpdated(GameManager.GameState newState)
    {
        if(newState == GameManager.GameState.GameOver)
        {
            displayedPoints = 0;
            pointsLabel.text = displayedPoints.ToString();
        }
    }

    void UpdatePoints()
    {
        StartCoroutine(UpdatePointsCoroutine());
    }

    IEnumerator UpdatePointsCoroutine()
    {
        var ogPosition = icon.anchoredPosition;
        var tween = icon.DOShakeAnchorPos(0.25f, 20, 30).SetEase(Ease.InBounce);
        tween.SetLoops(-1);
        while (displayedPoints < GameManager.Instance.Points)
        {
            displayedPoints++;
            pointsLabel.text = displayedPoints.ToString("D5");
            yield return new WaitForSeconds(0.1f);
        }
        tween.Kill();
        icon.anchoredPosition = ogPosition;
        yield return null;
    }
}
