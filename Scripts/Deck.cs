using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] GameObject playerHand;
    [SerializeField] GameObject cardPrefab;

    private List<Card2> currentDeck = new List<Card2>();

    private void OnMouseDown()
    {
        Instantiate(cardPrefab, playerHand.transform);
        CardCollection.IncreaseCurrentCardIndex();
    }

    public void AddNewCardsToDeck()
    {
        // Добавляем 5 карт в текущую колоду после каждого раунда
        for (int i = 0; i < 5; i++)
        {
            currentDeck.Add(CardCollection.TakeCard());
        }
    }

    private void MakeNewDeck()
    {
        AddNewCardsToDeck();
        ShuffleCards();
    }

    private void ShuffleCards()
    {
        Card2[] tempDeck = new Card2[currentDeck.Count];

        for (int i = tempDeck.Length - 1; i >= 1; i--)
        {
            // Генерируем случайный индекс в диапазоне от 0 до i
            int j = Random.Range(0, i + 1);

            // Меняем местами элементы с индексами i и j
            tempDeck[i] = currentDeck[j];
            tempDeck[j] = currentDeck[i];
        }

        currentDeck = tempDeck.ToList();
    }

    private void Start()
    {
        //AddNewCardsToDeck();
        //AddNewCardsToDeck();
    }
}
