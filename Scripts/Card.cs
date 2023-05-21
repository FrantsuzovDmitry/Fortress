using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card
{
    public int id;
    public string cardName;
    public int manaCost;
    public int attack;
    public string cardDescription;
    public Sprite spriteImage;

    public Card()
    {

    }

    public Card(int id, string cardName, int cost, int power, string cardDescription, Sprite sprite)
    {
        this.id = id;
        this.cardName = cardName;
        this.manaCost = cost;
        this.attack = power;
        this.cardDescription = cardDescription;
        this.spriteImage = sprite;
    }
}
