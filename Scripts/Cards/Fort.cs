using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fort : Card2
{
    //[SerializeField] byte rate;
    byte _rate;

    public Fort(byte rate, string logoPath)
    {
        _rate = rate;
        SetCardImage(logoPath);
    }
}
