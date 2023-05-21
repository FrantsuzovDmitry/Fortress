using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public int x;
    public static int deckSize;
    public static List<Card> staticDeck = new List<Card>();

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    private const short NumberOfTypes = 5;

    public GameObject cardToHand;
    public GameObject[] clones;
    public GameObject hand;

    void Start()
    {
        deckSize = deck.Count;

        // Creating of deck
        for (int i = 0; i < deckSize; i++)
        {
            x = Random.Range(1, NumberOfTypes);     // exclude zero card
            deck[i] = CardDatabase.cardList[x];
        }

        StartCoroutine(StartGame());
    }

    private void FixedUpdate()
    {
        staticDeck = deck;

        if (deckSize < 30) 
        {
            cardInDeck4.SetActive(false);
        }
        if (deckSize < 20)
        {
            cardInDeck3.SetActive(false);
        }
        if (deckSize < 10)
        {
            cardInDeck2.SetActive(false);
        }
        if (deckSize < 1)
        {
            cardInDeck1.SetActive(false);
        }

        if (TurnSystem.startTurn)
        {
            StartCoroutine(Draw(1));
            TurnSystem.startTurn = false;
        }
    }

    public void Shuffle()
    {
        for (int i = 0; i < deckSize; i++)
        {
            var temp = deck[i];
            int randIndex = Random.Range(i, deckSize);
            deck[i] = deck[randIndex];
            deck[randIndex] = temp;
        }
    }

    IEnumerator StartGame()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(cardToHand, transform.position, transform.rotation);
        }
    }

    IEnumerator Draw(int x)
    {
        for (int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(cardToHand, transform.position, transform.rotation);
        }
    }
}
