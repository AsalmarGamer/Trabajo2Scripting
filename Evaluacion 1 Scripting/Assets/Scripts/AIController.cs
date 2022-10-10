using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AIController : MonoBehaviour
{
    [SerializeField] public GameObject Player;

    [SerializeField] private List<Vector2Int> path;
    [SerializeField] private int speed = 5;
    [SerializeField] private int x = 0;
    [SerializeField] public int MaxDistance = 5;
    [SerializeField] public int ActionPoints = 2;
    [SerializeField] private bool isMoving;
    [SerializeField] private bool isAtking;
    [SerializeField] private bool AITurn;

    public TurnManager TM;

    void Update()
    {
        if (AITurn == true)
        {
            if (isMoving == false && MaxDistance != 0)
            {
                path = PathGenerator.pathFinding.FindPath(PositionToVector2Int(), PlayerPositionToVector2Int());
                {
                    isMoving = true;
                }
            }

            if (isAtking == true) //&& ActionPoints != 0)
            {
                path = PathGenerator.pathFinding.FindPath(PositionToVector2Int(), PlayerPositionToVector2Int());
                Debug.Log(path);
            }
        }
    }

    public void AIStartTurn()
    {
        AITurn = true;
        MaxDistance = 5;
        ActionPoints = 2;
    }

    public void AIEndTurn()
    {
        AITurn = false;
        MaxDistance = 5;
        ActionPoints = 2;
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            Patrol(path);
        }
    }

    private void MoveCharacter(Vector2 destination)
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.fixedDeltaTime);
    }

    private void Patrol(List<Vector2Int> patrolPoints)
    {
        float distance = Vector2.Distance(transform.position, patrolPoints[x]);
        if (distance > 0) MoveCharacter(patrolPoints[x]);
        else if (distance == 0) x++;

        if (x + 1 == patrolPoints.Count)
        {
            MaxDistance = MaxDistance - x;
            x = 0;
            isMoving = false;
            isAtking = true;

        }

        if (MaxDistance == x)
        {
            MaxDistance = MaxDistance - x;
            x = 0;
            isMoving = false;

            if(isMoving == false && isAtking == false)TM.EndAITurn();
        }


    }
    private Vector2Int PlayerPositionToVector2Int()
    {
        return Vector2Int.RoundToInt(Player.transform.position);
    }

    private Vector2Int PositionToVector2Int()
    {
        return Vector2Int.RoundToInt(transform.position);
    }
}
