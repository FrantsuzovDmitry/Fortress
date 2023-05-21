using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplayBehaviour : MonoBehaviour
{
    [SerializeField] Deck deck;
    public Card2 selfCard;
    public Image logo;

    public void DisplayCard(Card2 card)
    {
        selfCard = card;
        //Image cardImage = GetComponent<Image>();
        logo.sprite = card.logo;
        //Сохранять соотношения сторон
        logo.preserveAspect = true;
    }

    private void Start()
    {
        DisplayCard(CardCollection.cards[CardCollection.CurrentCardIndex]);
        //DisplayCard(CardCollection.cards[selfCard.CardIndex]);
    }
}
