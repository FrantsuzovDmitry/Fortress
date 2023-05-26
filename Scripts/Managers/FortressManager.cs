using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FortressManager : MonoBehaviour
{
    public static FortressManager instance;
    public Dictionary<Player, List<Fortress>> capturedFortresses = new();
    public List<Fortress> notCapturedFortress = new List<Fortress>();

    private void Awake()
    {
        instance = this;
    }

    public void AttackToFortress(CardController defendingFort)
    {
        int attackerID = TurnManager.instance.currentPlayerTurn;
        var groupOfCharacters = CardManager.instance.GroupOfCharacters;
        int totalForce = 0, totalWeight = 0;
        foreach (Character character in groupOfCharacters)
        {
            character.EnterInGroup(ref totalForce, ref totalWeight);
        }

        if (totalForce > 0)
        {
            Player attacker = PlayerManager.instance.FindPlayerByID(attackerID);
            notCapturedFortress.Find(x => x == defendingFort.card).AddDefenders(groupOfCharacters);

            // Adding new Fort to the player collection
            if (capturedFortresses.ContainsKey(attacker))
            {
                capturedFortresses[attacker].Add((Fortress)defendingFort.card);
            }
            // Creating of new pair Player - Fort
            else
            {
                capturedFortresses.Add(attacker, new List<Fortress> { (Fortress)defendingFort.card });
            }

            notCapturedFortress.Remove((Fortress)defendingFort.card);
            CardManager.instance.ChangeParentPosition(defendingFort);
            //CardManager.instance.RemoveAttackersFromHand();

            Debug.Log("Successful attack: TotalForce = " + totalForce * totalWeight);
        }
        else
        {
            Debug.Log("Unsuccessful attack");
        }

        TurnManager.instance.onAttackStopped?.Invoke();
    }

    // Called when the Unity-object is active
    private void OnEnable()
    {
        // Subscribe to action
        //CardManager.instance.onFortAdded += AddFort;
        Observer.onFortressAttacked += AttackToFortress;
    }

    public void AddFort(Card fort)
    {
        notCapturedFortress.Add((Fortress)fort);
    }
}
