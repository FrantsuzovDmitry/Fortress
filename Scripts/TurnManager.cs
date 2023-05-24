using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;
    public int currentPlayerTurn;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartTurnGameplay(0);
    }

    public void StartTurnGameplay(int playerID)
    {
        currentPlayerTurn = playerID;
        StartTurn();
    }

    public void StartTurn()
    {
        GameplayUIController.instance.UpdateCurrentPlayerTurn(currentPlayerTurn);
        PlayerManager.instance.AssignTurn(currentPlayerTurn);
    }

    public void EndTurn()
    {
        var lastPlayerID = PlayerManager.instance.players.Last().ID;
        if (currentPlayerTurn == lastPlayerID)
        {
            // Firt player turn
            currentPlayerTurn = 0;
        }
        else
        {
            // Next player turn;
            currentPlayerTurn = currentPlayerTurn + 1;
        }
        StartTurn();
    }
}
