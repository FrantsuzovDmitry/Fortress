using UnityEngine;

public class Fort : Card
{
    public int rate;

    public Fort() { }

    public Fort(int rate, Sprite illustrarion) : base("Fort", illustrarion)
    {
        this.rate = rate;
    }

    public Fort(Card card, int rate) : base(card)
    {
        this.rate = rate;
    }
}
