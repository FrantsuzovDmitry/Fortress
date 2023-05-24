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

    public void AttackToFortress(int attackerID, Fortress defendingFort, List<Character> groupOfCharacters)
    {
        int totalForce = 0, totalWeight = 0;
        foreach (Character character in groupOfCharacters)
        {
            totalForce += character.force;
            totalWeight += character.weight;
        }

        if (totalForce > 0)
        {
            Player attacker = PlayerManager.instance.FindPlayerByID(attackerID);
            notCapturedFortress.Find(x => x == defendingFort).AddDefenders(groupOfCharacters);

            // Adding new Fort to the player collection
            if (capturedFortresses.ContainsKey(attacker))
            {
                capturedFortresses[attacker].Add(defendingFort);
            }
            // Creating of new pair Player - Fort
            else
            {
                capturedFortresses.Add(attacker, new List<Fortress> { defendingFort });
            }

            notCapturedFortress.Remove(defendingFort);
            CardManager.instance.RemoveAttackersFromHand();

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
    }

    public void AddFort(Card fort)
    {
        notCapturedFortress.Add((Fortress)fort);
    }
}
