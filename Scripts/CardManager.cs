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
    public List<Character> groupOfCharacters = new List<Character>();

    public int numberOfSandglasses;

    private const int NotAPlayerID = 100;

    public delegate void OnFortAdded(Card card);
    public OnFortAdded onFortAdded;

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
        deck.Add(new Fortress(3, Resources.Load<Sprite>("Sprites/2")));
        deck.Add(new Character(2, 1, 1, Resources.Load<Sprite>("Sprites/4")));
        deck.Add(new Character(1, 1, 1, Resources.Load<Sprite>("Sprites/5")));
        deck.Add(new Character(2, 1, 1, Resources.Load<Sprite>("Sprites/6")));
        deck.Add(new Character(3, 1, 1, Resources.Load<Sprite>("Sprites/9")));
        deck.Add(new Character(3, 1, 1, Resources.Load<Sprite>("Sprites/9")));
        deck.Add(new Character(3, 1, 1, Resources.Load<Sprite>("Sprites/9")));
        deck.Add(new Character(3, 1, 1, Resources.Load<Sprite>("Sprites/9")));
        deck.Add(new Character(3, 1, 1, Resources.Load<Sprite>("Sprites/9")));
        deck.Add(new Character(3, 1, 1, Resources.Load<Sprite>("Sprites/9")));
        deck.Add(new Fortress(1, Resources.Load<Sprite>("Sprites/2")));
    }

    public void GiveCardToPlayer(int playerID)
    {
        Card card = deck[deck.Count - 1];
        CardController newCard;
        if (card is Sandglass || card is Fortress)
        {
            newCard = Instantiate(cardControllerPrefab, playArea);
            newCard.transform.localPosition = Vector3.zero;
            newCard.Initialize(card, NotAPlayerID);

            if (card is Sandglass)
                IncreaseNumberOfSandglasses();
            if (card is Fortress)
                FortressManager.instance.AddFort(card);
        }
        else
        {
            newCard = Instantiate(cardControllerPrefab, player1Hand);
            newCard.transform.localPosition = Vector3.zero;
            newCard.Initialize(card, playerID);

            playersCards[playerID].Add(newCard);        // Action
            player1Cards.Add(newCard);                  // Same action (but concrete)
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

    public void AddCharacterToGroup(Character character)
    {
        groupOfCharacters.Add(character);
    }

    public void RemoveCharacterFromGroup(Character character)
    {
        groupOfCharacters.Remove(character);
    }

    public void StopCreatingOfGroup()
    {
        groupOfCharacters.Clear();
    }

    public void RemoveAttackersFromHand()
    {
        int i = 0;
        while (i < player1Cards.Count)
        {
            var card = player1Cards[i];
            // if card was in the attackers group then card will be removed
            if (((Character)card.card).isInGroup)
            {
                Destroy(player1Cards[i].gameObject);
                player1Cards.Remove(card);
            }
            else
            {
                i++;
            }
        }
    }

    public void HideOpponentsCards()
    {
        if (TurnManager.instance.currentPlayerTurn == 0)
        {
            foreach (CardController card in player2Cards)
            {
                card.cardBack.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (CardController card in player1Cards)
            {
                card.cardBack.gameObject.SetActive(true);
            }
        }
    }

    public void ShowMyCards()
    {
        if (TurnManager.instance.currentPlayerTurn == 1)
        {
            foreach (CardController card in player2Cards)
            {
                card.cardBack.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (CardController card in player1Cards)
            {
                card.cardBack.gameObject.SetActive(false);
            }
        }
    }

    public void AttackToFortress(int attackerID, Fortress defendingFort)
    {
        FortressManager.instance.AttackToFortress(attackerID, defendingFort, groupOfCharacters);
    }

    private void OnEnable()
    {
        TurnManager.instance.onAttackStopped += StopCreatingOfGroup;
    }

    private void OnDisable()
    {
        
    }
}