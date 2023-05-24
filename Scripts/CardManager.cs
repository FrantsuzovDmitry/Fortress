using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;
    public List<Card>
            cards = new List<Card>(),
            deck = new List<Card>();
    public Transform player1Hand, player2Hand, player3Hand, player4Hand, playArea;
    public CardController cardControllerPrefab;
    public List<CardController>
            player1Cards = new List<CardController>(),
            player2Cards = new List<CardController>(),
            player3Cards = new List<CardController>(),
            player4Cards = new List<CardController>();
    public List<List<CardController>> playersCards = new List<List<CardController>>();

    public int numberOfSandglasses;

    private const int NotAPlayerID = 100;

    //Initialization
    private void Awake()
    {
        instance = this;
        numberOfSandglasses = 0;
        for (int i = 0; i < 4; i++) playersCards.Add(new List<CardController>());
    }

    private void Start()
    {
        FillDeck();
        //GenerateCards();
    }

    // A.k.a. GenerateDeck method
    private void FillDeck()
    {
        // Real deck (for now is locked)
        /*
        for (int i = 0; i < 10; i++)
        {
            string logoPath = "Card pictures/" + (i + 1);
            Sprite logo = Resources.Load<Sprite>(logoPath);
            var ClassName = CardDatabase.CardTemplates[i].ClassName;
            var force = CardDatabase.CardTemplates[i].force;
            var weight = CardDatabase.CardTemplates[i].weight;
            var rate = CardDatabase.CardTemplates[i].rate;

            switch (CardDatabase.CardTemplates[i].ClassName)
            {
                case "Rule":
                    //deck.Add(new Rule(logoPath));
                    break;
                case "Fort":
                    deck.Add(new Fort());
                    break;
                case "Character":

                    break;
                case "Sandglasses":

                    break;
            }
        }
        */

        // Test deck
        string logoPath = "Sprites/" + 1;
        Sprite logo = Resources.Load<Sprite>(logoPath);
        deck.Add(new Sandglass(Resources.Load<Sprite>("Sprites/10")));
        deck.Add(new Sandglass(Resources.Load<Sprite>("Sprites/10")));
        deck.Add(new Sandglass(Resources.Load<Sprite>("Sprites/10")));
        deck.Add(new Fort(1, Resources.Load<Sprite>("Sprites/2")));
        deck.Add(new Character(1, 1, 1, Resources.Load<Sprite>("Sprites/4")));
        deck.Add(new Character(2, 1, 1, Resources.Load<Sprite>("Sprites/5")));
        deck.Add(new Character(1, 1, 1, Resources.Load<Sprite>("Sprites/6")));
        deck.Add(new Fort(1, Resources.Load<Sprite>("Sprites/2")));
        deck.Add(new Character(3, 1, 1, Resources.Load<Sprite>("Sprites/9")));
        deck.Add(new Character(3, 1, 1, Resources.Load<Sprite>("Sprites/9")));
        deck.Add(new Character(3, 1, 1, Resources.Load<Sprite>("Sprites/9")));
        deck.Add(new Character(3, 1, 1, Resources.Load<Sprite>("Sprites/9")));
        deck.Add(new Character(3, 1, 1, Resources.Load<Sprite>("Sprites/9")));
        deck.Add(new Character(3, 1, 1, Resources.Load<Sprite>("Sprites/9")));
    }

    public void GiveCardToPlayer(int playerID)
    {
        var card = deck[deck.Count - 1];
        CardController newCard;
        if (card is Sandglass || card is Fort)
        {
            newCard = Instantiate(cardControllerPrefab, playArea);
            newCard.transform.localPosition = Vector3.zero;
            newCard.Initialize(card, NotAPlayerID);

            if (card is Sandglass)
                IncreaseNumberOfSandglasses();
        }
        else
        {
            newCard = Instantiate(cardControllerPrefab, player1Hand);
            newCard.transform.localPosition = Vector3.zero;
            newCard.Initialize(card, playerID);

            playersCards[playerID].Add(newCard);
            player1Cards.Add(newCard);
        }

        // Delete last card
        deck.RemoveAt(deck.Count - 1);
    }

    private void GenerateCards()
    {
        foreach (Card card in deck)
        {
            CardController newCard = Instantiate(cardControllerPrefab, player1Hand);
            newCard.transform.localPosition = Vector3.zero;
            newCard.Initialize(card, 0);
        }
    }

    public void IncreaseNumberOfSandglasses()
    {
        numberOfSandglasses++;
        CheckOfStopGameCondition();
    }

    private void CheckOfStopGameCondition()
    {
        if (numberOfSandglasses == 3)
        {
            PlayerManager.instance.EndGame();
        }
    }
}

