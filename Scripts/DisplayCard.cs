using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new List<Card>();
    public int displayId;       //номер отображаемой карты

    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;
    public Sprite spriteImage;

    public Text costText;
    public Text nameText;
    public Text powerText;
    public Text descriptionText;
    public Image artImage;

    public bool isCardBack;

    public GameObject Hand;
    public int numberOfCardsInDeck;

    void Start()
    {
        //displayCard[0] = CardDatabase.cardList[displayId];  // тип отображаемой карты
        numberOfCardsInDeck = PlayerDeck.deckSize;
        Hand = GameObject.Find("Hand"); 

    }

    private void FixedUpdate()
    {
        id = displayCard[0].id;
        cardName = displayCard[0].cardName;
        cost = displayCard[0].manaCost;
        power = displayCard[0].attack;
        cardDescription = displayCard[0].cardDescription;
        spriteImage = displayCard[0].spriteImage;

        nameText.text = "" + cardName;
        costText.text = "" + cost;
        powerText.text = "" + power;
        descriptionText.text = "" + cardDescription;
        artImage.sprite = spriteImage;

        if (this.tag == "Clone")
        {
            displayCard[0] = PlayerDeck.staticDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck--;
            PlayerDeck.deckSize--;
            isCardBack = false;
            this.tag = "Untagged";
            return;
        }

        if (this.transform.parent == Hand.transform.parent)
        {
            isCardBack = false;
        }
    }
}
