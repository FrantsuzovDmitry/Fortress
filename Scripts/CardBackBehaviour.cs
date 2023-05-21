using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBackBehaviour : MonoBehaviour
{
    public GameObject CardBack;

    private DisplayCard displayBehaviour;

    void Start()
    {
        displayBehaviour = GetComponent<DisplayCard>();
    }

    void Update()
    {
        if (displayBehaviour.isCardBack)
        {
            CardBack.SetActive(true);
        }
        else
        {
            CardBack.SetActive(false);
        }
    }
}
