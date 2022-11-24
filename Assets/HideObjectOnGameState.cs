using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObjectOnGameState : MonoBehaviour
{
    public GameObject target;
    public GameManager.GameState showOnState;

    // Start is called before the first frame update
    void Start()
    {
        target.SetActive(showOnState == GameManager.Instance.gameState);
        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
    }

    private void GameStateUpdated(GameManager.GameState newState)
    {
        target.SetActive(showOnState == GameManager.Instance.gameState);
    }

}
