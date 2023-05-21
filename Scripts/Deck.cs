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
        // ��������� 5 ���� � ������� ������ ����� ������� ������
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
            // ���������� ��������� ������ � ��������� �� 0 �� i
            int j = Random.Range(0, i + 1);

            // ������ ������� �������� � ��������� i � j
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
