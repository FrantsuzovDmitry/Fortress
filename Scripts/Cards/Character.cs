using UnityEngine;

public class Character : Card
{
    public int force, weight;

    public Character() : base() { }

    public Character(Character card) : base(card)
    {
        this.force = card.force;
    }

    public Character(int force, int weight, int ownerID, Sprite illustrarion) : base("Character", illustrarion)
    {
        this.force = force;
        this.weight = weight;
    }
}
