using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    private const int MoveStraightValue = 10;
    private const int MoveDiagonalValue = 14;
    private GridLogic<PathNode> grid;
    private List<PathNode> OpenList;
    private List<PathNode> CloseList;
    public Pathfinding(int width, int height, Vector3 position)
    {
        grid = new GridLogic<PathNode>(width, height, 1, position,
            (GridLogic<PathNode> g, int x, int y) => new PathNode(g, x, y));
    }

    public List<PathNode> FindPath(int startX, int startY,int endX,int endY)
    {
        PathNode startNode = grid.GetGridObject(startX, startY);
        PathNode endNode = grid.GetGridObject(endX, endY);
        OpenList = new List<PathNode>{startNode};
        CloseList = new List<PathNode>();
        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                PathNode pathNode = grid.GetGridObject(x, y);
                pathNode.gCost = int.MaxValue;
                pathNode.CalculFCost();
                pathNode.ParentNode = null;
            }
        }

        startNode.gCost = 0;
        startNode.hCost = CalculDistanceCost(startNode, endNode);
        startNode.CalculFCost();

        while (OpenList.Count>0)
        {
            PathNode currentNode = GetLowestFCostNode(OpenList);
            if (currentNode==endNode)
            {
               return CalculFinalPath(endNode);
            }
            else
            {
                OpenList.Remove(currentNode);
                CloseList.Add(currentNode);
                foreach (PathNode pathNode in GetNeighbourList(currentNode))
                {
                    if (CloseList.Contains(pathNode)==false)
                    {
                        int NewPotentialGCost = currentNode.gCost + CalculDistanceCost(currentNode, pathNode);
                        if (NewPotentialGCost < pathNode.gCost)
                        {
                            pathNode.ParentNode = currentNode;
                            pathNode.gCost = NewPotentialGCost;
                            pathNode.hCost = CalculDistanceCost(pathNode, endNode);
                            pathNode.CalculFCost();
                        }

                        if (OpenList.Contains(pathNode)==false)
                        {
                            OpenList.Add(pathNode);
                        }
                    }
                }
            }
        }

        return null;

    }
    private List<PathNode> GetNeighbourList(PathNode currentNode) {
        List<PathNode> neighbourList = new List<PathNode>();

        if (currentNode._x - 1 >= 0) {
            neighbourList.Add(grid.GetGridObject(currentNode._x - 1, currentNode._y));
            if (currentNode._y - 1 >= 0) neighbourList.Add(grid.GetGridObject(currentNode._x - 1, currentNode._y - 1));
            if (currentNode._y + 1 < grid.GetHeight()) neighbourList.Add(grid.GetGridObject(currentNode._x - 1, currentNode._y + 1));
        }
        if (currentNode._x + 1 < grid.GetWidth()) {
            neighbourList.Add(grid.GetGridObject(currentNode._x + 1, currentNode._y));
            if (currentNode._y - 1 >= 0) neighbourList.Add(grid.GetGridObject(currentNode._x + 1, currentNode._y - 1));
            if (currentNode._y + 1 < grid.GetHeight()) neighbourList.Add(grid.GetGridObject(currentNode._x + 1, currentNode._y + 1));
        }
        if (currentNode._y - 1 >= 0) neighbourList.Add(grid.GetGridObject(currentNode._x, currentNode._y - 1));
        if (currentNode._y + 1 < grid.GetHeight()) neighbourList.Add(grid.GetGridObject(currentNode._x, currentNode._y + 1));

        return neighbourList;
    }

    private int CalculDistanceCost(PathNode a, PathNode b)
    {
        int xDistance = Mathf.Abs(a._x - b._x);
        int yDistance = Mathf.Abs(a._y - b._y);
        int remaining = Mathf.Abs(xDistance - yDistance);
        return MoveDiagonalValue * Mathf.Min(xDistance, yDistance) + MoveStraightValue * remaining;
    }

    private PathNode GetLowestFCostNode(List<PathNode> pathNodes)
    {
        PathNode LowestFCostNode = pathNodes[0];
        for (int i = 1; i < pathNodes.Count; i++)
        {
            if (pathNodes[i].fCost <LowestFCostNode.fCost)
            {
                LowestFCostNode = pathNodes[i];
            }
        }

        return LowestFCostNode;
    }

    private List<PathNode> CalculFinalPath(PathNode endNode)
    {
        List<PathNode> FinalPath = new List<PathNode>();
        FinalPath.Add(endNode);
        PathNode currentNode = endNode;
        while (currentNode.ParentNode != null)
        {
            FinalPath.Add(currentNode.ParentNode);
            currentNode = currentNode.ParentNode;
        }
        FinalPath.Reverse();
        return FinalPath;
    }
}
