using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Card card;
    public Image illustration, image;
    public TextMeshProUGUI cardName;

    public Transform originalParent;    //Make private

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Initialize(Card card, int ownerID)
    {
        this.card = new Card(card)
        {
            ownerID = ownerID
        };
        illustration.sprite = card.illustration;
        cardName.text = card.cardName;

        originalParent = transform.parent;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Entered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (originalParent.name != $"Player{card.ownerID+1}Hand")
            //TurnManager.instance.currentPlayerTurn != card.ownerID)
        {
            Debug.Log("It's not your hand of not your turn!");
        }
        else
        {
            // Parent of the parent (UI in our case)
            transform.SetParent(transform.root);
            image.raycastTarget = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log(eventData.pointerEnter);
        image.raycastTarget = true;
        ReturnRoHand();
    }

    private void ReturnRoHand()
    {
        transform.SetParent(originalParent);
        transform.localPosition = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //transform.position = eventData.position;
        if (transform.parent == originalParent) return;
        transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0);
    }
}
