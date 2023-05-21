using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public static float maxHP;
    public static float staticHP;
    public float HP;

    public Image Health;    // UI Health circle
    public Text hpText;

    void Start()
    {
        maxHP = 25000;
        staticHP = 20000;
    }

    void Update()
    {
        HP = staticHP;
        Health.fillAmount = HP / maxHP;     // part of health;

        if (HP >= maxHP )
            HP = maxHP;

        hpText.text = HP + "HP";
    }
}
