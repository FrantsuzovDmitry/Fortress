using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    // Turn block
    public bool isYourTurn;
    public int yourTurn;
    public int isOpponentTurn;
    public Text turnText;

    // Mana block
    public int maxMana;
    public int currentMana;
    public Text manaText;

    public static bool startTurn;


    void Start()
    {
        isYourTurn = true;
        yourTurn = 1;
        isOpponentTurn = 0;

        maxMana = currentMana = 1;

        startTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isYourTurn)
        {
            turnText.text = "Your Turn!";
        }
        else
        {
            turnText.text = "Opponent Turn!";
        }

        manaText.text = currentMana + "/" + maxMana;
    }

    public void EndYourTurn()
    {
        isYourTurn = false;
        isOpponentTurn++;
    }

    public void EndOpponentTurn()
    {
        isYourTurn = true;
        yourTurn++;

        maxMana += 1;
        currentMana = maxMana;

        startTurn = true;
    }
}
