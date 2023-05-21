using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    private void Awake()
    {
        cardList.Add(new Card(0, "None", 0, 0, "None", Resources.Load<Sprite>("Sprites/1")));
        cardList.Add(new Card(1, "Human", 2, 1, "None", Resources.Load<Sprite>("Sprites/1")));
        cardList.Add(new Card(2, "Elf", 2, 1, "None", Resources.Load<Sprite>("Sprites/1")));
        cardList.Add(new Card(3, "Dwarf", 2, 1, "None", Resources.Load<Sprite>("Sprites/1")));
        cardList.Add(new Card(4, "Troll", 2, 1, "None", Resources.Load<Sprite>("Sprites/1")));
    }
}
