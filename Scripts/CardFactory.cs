using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CardTemplate
{
    public string ClassName;
    public byte force;
    public byte weight;
    public byte rate;

    public CardTemplate(string name, byte force, byte weight, byte rate)
    {
        this.ClassName = name;
        this.force = force;
        this.weight = weight;
        this.rate = rate;
    }
}

public static class CardCollection
{
    private const int NumberOfCards = 15;
    private static int currentCardIndex = 0;

    public static Card2[] cards = new Card2[NumberOfCards];

    public static int CurrentCardIndex { get => currentCardIndex; }

    public static void IncreaseCurrentCardIndex()
    {
        if (currentCardIndex == NumberOfCards - 1)
            throw new System.Exception("Deck is empty!");

        currentCardIndex++;
    }
    public static Card2 TakeCard()
    {
        IncreaseCurrentCardIndex();
        if (currentCardIndex == NumberOfCards - 1)
            throw new System.Exception("Deck is empty!");

        return cards[currentCardIndex - 1];
    }


}

public class CardFactory : MonoBehaviour
{
    // Оригинальная колода
    public static CardTemplate[] CardTemplates = new CardTemplate[10]
    {
        new CardTemplate("Rule",        0, 0, 0),
        new CardTemplate("Fort",        0, 0, 3),
        new CardTemplate("Character",   1, 1, 0),
        new CardTemplate("Character",   2, 1, 0),
        new CardTemplate("Character",   1, 1, 0),
        new CardTemplate("Character",   2, 1, 0),
        new CardTemplate("Rule",        0, 0, 0),
        new CardTemplate("Rule",        0, 0, 0),
        new CardTemplate("Character",   3, 1, 0),
        new CardTemplate("Sandglasses", 0, 0, 0),
    };

    public void Awake()
    {
        /*
         * Это оригинальная колода. Тестить будем на той, что указана ниже
        for (int i = 0; i < 10; i++)
        {
            string logoPath = "Card pictures/" + (i + 1);
            switch (CardTemplates[i].ClassName)
            {
                case "Rule":
                    CardCollection.cards[i] = new Rule(logoPath);
                    break;
                case "Fort":
                    CardCollection.cards[i] = new Fort(CardTemplates[i].rate, logoPath);
                    break;
                case "Character":
                    CardCollection.cards[i] = new Character(CardTemplates[i].force, CardTemplates[i].weight, logoPath);
                    break;
                case "Sandglasses":
                    CardCollection.cards[i] = new Character(CardTemplates[i].force, CardTemplates[i].weight, logoPath);
                    break;
            }
        }
        */

        // Тестовая колода
        CardCollection.cards[0] = new Fort(3, "Card pictures/2");
        CardCollection.cards[1] = new Character(1, 1, "Card pictures/3");
        CardCollection.cards[2] = new Character(2, 1, "Card pictures/4");
        CardCollection.cards[3] = new Character(1, 1, "Card pictures/5");
        CardCollection.cards[4] = new Character(2, 1, "Card pictures/6");
        CardCollection.cards[5] = new Fort(1, "Card pictures/2");
        CardCollection.cards[6] = new Character(3, 1, "Card pictures/9");
        CardCollection.cards[7] = new Character(3, 1, "Card pictures/9");
        CardCollection.cards[8] = new Character(3, 1, "Card pictures/9");
        CardCollection.cards[9] = new Character(3, 1, "Card pictures/9");
        CardCollection.cards[10] = new Character(3, 1, "Card pictures/9");
        CardCollection.cards[11] = new Character(3, 1, "Card pictures/9");
        CardCollection.cards[12] = new Sandglasses("Card pictures/10");
        CardCollection.cards[13] = new Sandglasses("Card pictures/10");
        CardCollection.cards[14] = new Sandglasses("Card pictures/10");
    }
}
