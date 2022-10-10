using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private UnityEvent StartPlayerTurn;
    [SerializeField] private UnityEvent EndPlayerTurn;
    public GameObject Player;
    [SerializeField] private UnityEvent StartEnemyTurn;
    [SerializeField] private UnityEvent EndEnemyTurn;
    public GameObject Enemy;
    public bool PTurn;
    public bool ETurn = true;

    public void P1StartTurn()
    {
        PTurn = true;
        StartPlayerTurn.Invoke();

        Debug.Log("P1StartTurn");
    }
    public void P1EndTurn()
    {
        if (PTurn == true) { EndPlayerTurn.Invoke(); PTurn = false; Debug.Log("P1ENDTurn"); }

    }

    public void StartAITurn()
    {
        ETurn = true;
        StartEnemyTurn.Invoke();
        Debug.Log("Start AI turn");
    }
    public void EndAITurn()
    {
        if (ETurn == true) { EndEnemyTurn.Invoke(); ETurn = false; Debug.Log("END AI turn"); }
    }
    
}
