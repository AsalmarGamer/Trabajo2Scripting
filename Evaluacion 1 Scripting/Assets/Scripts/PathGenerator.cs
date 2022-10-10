using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    private List<Walkable> _grid;
    public static PathFinding pathFinding;

    private void Start()
    {
        _grid = new List<Walkable>(FindObjectsOfType<Walkable>());
        pathFinding = new PathFinding(_grid);
    }

}
