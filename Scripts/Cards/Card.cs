using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Card2
{
    public Sprite logo;
    public int id;

    protected void SetCardImage(string logoPath)
    {
        logo = Resources.Load<Sprite>(logoPath);
    }
}
