using System;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding
{
    private Walkable _startCell;
    private Walkable _endCell;
    private List<Walkable> _grid;
    private int diagonalCost;
    private int straightCost;

    public PathFinding(List<Walkable> grid)
    {
        _grid = grid;
    }

    public List<Vector2Int> FindPath(Vector2Int start, Vector2Int end)
    {
        bool startLokated = false;
        bool endLokated = false;

        for (int i = 0; i < _grid.Count; i++)
        {
            if (startLokated && endLokated) break;
            if (_grid[i].GetCellID() == start)
            {
                _startCell = _grid[i];
                startLokated = true;
            }
            if (_grid[i].GetCellID() == end)
            {
                _endCell = _grid[i];
                endLokated = true;
            }
        }

        List<Walkable> openList = new List<Walkable> { _startCell };
        List<Walkable> closedList = new List<Walkable>();

        for (int i = 0; i < _grid.Count; i++)
        {
            _grid[i].SetGCost(int.MaxValue);
            _grid[i].CalculateFCost();
            _grid[i].SetCameFromCell(null);
        }

        _startCell.SetGCost(0);
        _startCell.SetHCost(CalculateDistanceCost(_startCell, _endCell));
        _startCell.CalculateFCost();

        while (openList.Count > 0)
        {
            Walkable currentCell = GetLowestFCostCell(openList);

            if (currentCell == _endCell) return CalculatePath(_endCell);

            openList.Remove(currentCell);
            closedList.Add(currentCell);

            foreach (Walkable neighbourCell in GetNeighboursList(currentCell, _grid))
            {
                if (closedList.Contains(neighbourCell)) continue;

                int tentativeCost = currentCell.GetGCost() + CalculateDistanceCost(currentCell, neighbourCell);
                if (tentativeCost < neighbourCell.GetGCost())
                {
                    neighbourCell.SetCameFromCell(currentCell);
                    neighbourCell.SetGCost(tentativeCost);
                    neighbourCell.SetHCost(CalculateDistanceCost(neighbourCell, _endCell));
                    neighbourCell.CalculateFCost();
                }
                if (!openList.Contains(neighbourCell)) openList.Add(neighbourCell);
            }
        }
        return null;
    }



    

    private int CalculateDistanceCost(Walkable actualCell, Walkable endCell)
    {
        if (actualCell.CompareTag("Tierra") && endCell.CompareTag("Tierra")) { 
            diagonalCost = 2;
            straightCost = 1;
        }
        else
        {
            diagonalCost = 4;
            straightCost = 2;
        }
        
        int xDistance = (int)Mathf.Abs(actualCell.GetCellID().x - endCell.GetCellID().x);
        int yDistance = (int)Mathf.Abs(actualCell.GetCellID().y - endCell.GetCellID().y);
        int remaining = Math.Abs(xDistance - yDistance);

        return diagonalCost * Math.Min(xDistance, yDistance) + straightCost * remaining;
    }

    private Walkable GetLowestFCostCell(List<Walkable> openList)
    {
        Walkable lowestFCostCell = openList[0];
        for (int i = 0; i < openList.Count; i++)
        {
            if (openList[i].GetFCost() < lowestFCostCell.GetFCost()) lowestFCostCell = openList[i];
        }
        return lowestFCostCell;
    }

    private List<Walkable> GetNeighboursList(Walkable currentCell, List<Walkable> grid)
    {
        List<Walkable> neighboursList = new List<Walkable>();
        int x = currentCell.GetCellID().x;
        int y = currentCell.GetCellID().y;

        for (int i = 0; i < grid.Count; i++)
        {
            //INF DER
            //if (grid[i].GetCellID() == new Vector2Int(x + 1, y - 1)) neighboursList.Add(grid[i]);
            //SUP DER
            //if (grid[i].GetCellID() == new Vector2Int(x + 1, y + 1)) neighboursList.Add(grid[i]);
            //INF

            //INF IZQ
            //if (grid[i].GetCellID() == new Vector2Int(x - 1, y - 1)) neighboursList.Add(grid[i]);
            //SUP IZQ
            //if (grid[i].GetCellID() == new Vector2Int(x - 1, y + 1)) neighboursList.Add(grid[i]);
            

            //LEFT
            if (grid[i].GetCellID() == new Vector2Int(x - 1, y)) neighboursList.Add(grid[i]);
            //RIGHY
            if (grid[i].GetCellID() == new Vector2Int(x + 1, y)) neighboursList.Add(grid[i]);
            //DOWN
            if (grid[i].GetCellID() == new Vector2Int(x, y - 1)) neighboursList.Add(grid[i]);
            //UP
            if (grid[i].GetCellID() == new Vector2Int(x, y + 1)) neighboursList.Add(grid[i]);
        }
        return neighboursList;
    }

    private List<Vector2Int> CalculatePath(Walkable endCell)
    {
        List<Vector2Int> path = new List<Vector2Int>();
        path.Add(endCell.GetCellID());
        Walkable currentCell = endCell;
        while (currentCell.GetCameFromCell()!=null)
        {
            path.Add(currentCell.GetCameFromCell().GetCellID());
            currentCell = currentCell.GetCameFromCell();
        }
        path.Reverse();
        return path;
    }
}
