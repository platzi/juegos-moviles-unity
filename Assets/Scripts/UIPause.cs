using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPause : MonoBehaviour
{
    public void ContinueButtonPressed()
    {
        GameManager.Instance.ContinueGame();
    }

    public void ExitButtonPressed()
    {
        GameManager.Instance.ExitGame();
    }
}
