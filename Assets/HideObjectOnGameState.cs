using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObjectOnGameState : MonoBehaviour
{
    public GameObject target;
    public GameManager.GameState hideOnstate;

    // Start is called before the first frame update
    void Start()
    {
        if (hideOnstate == GameManager.Instance.gameState)
        {
            target.SetActive(false);
        }
        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
    }

    private void GameStateUpdated(GameManager.GameState newState)
    {
        target.SetActive(hideOnstate != newState);
    }

}
