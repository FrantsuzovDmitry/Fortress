using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joker : SimpleCharacter
{
    public Joker(Sprite logo) : base(0, 0, 0, logo) { }

    public override void EnterInGroup(ref int totalForce, ref int totalWeight)
    {
        if (totalForce == 0)
            return;
        else
            totalWeight++;
    }
}
