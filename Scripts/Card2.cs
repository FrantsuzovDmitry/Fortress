using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card2 : ScriptableObject
{
    public string name;
    public int manaCost;
    public string description;  
    public int attack;
}
