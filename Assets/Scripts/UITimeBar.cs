using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimeBar : MonoBehaviour
{
    public RectTransform fillRect;
    public Image bar;
    public Image fillColor;
    public Gradient gradient;

    private void Start()
    {
        bar.enabled = GameManager.Instance.gameState == GameManager.GameState.InGame;
        fillColor.enabled = GameManager.Instance.gameState == GameManager.GameState.InGame;
        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
    }

    private void GameStateUpdated(GameManager.GameState newState)
    {
        bar.enabled = newState == GameManager.GameState.InGame;
        fillColor.enabled = newState == GameManager.GameState.InGame;
    }

    // Update is called once per frame
    void Update()
    {
        float factor = GameManager.Instance.currentTimeToMatch / GameManager.Instance.timeToMatch;
        factor = Mathf.Clamp(factor, 0f, 1f);
        factor = 1 - factor;
        fillRect.localScale = new Vector3(factor, 1, 1);
        fillColor.color = gradient.Evaluate(factor);
    }
}
