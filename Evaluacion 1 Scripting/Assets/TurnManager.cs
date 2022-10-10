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
    public bool ETurn;

    public void P1StartTurn()
    {
        PTurn = true;
        StartPlayerTurn.Invoke();
    }
    public void P1EndTurn()
    {
        if (PTurn == true) { EndPlayerTurn.Invoke(); ETurn = false; }
    }

    public void StartAITurn()
    {
        ETurn = true;
        StartEnemyTurn.Invoke();
    }
    public void EndAITurn()
    {
        if (ETurn == true) { EndEnemyTurn.Invoke(); ETurn = false; }
    }
    
}
