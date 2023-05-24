using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameEndUIController gameEndUI;

    private void Awake()
    {
        instance = this;
    }

    // I suppose the better name is ShowWinner[Panel/Screen]
    // And maybe this function is better to be in GameplayUIController/Manager OR Move methods from the controller here
    public void GameFinished(Player winner)
    {
        gameEndUI.gameObject.SetActive(true);
        gameEndUI.Initialize(winner);
    }
}
