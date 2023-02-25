using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PathNode
{
   private GridLogic<PathNode> _grid;
   public int _x;
   public int _y;
   public int gCost;
   public int hCost;
   public int fCost;
   public PathNode ParentNode;
   public PathNode(GridLogic<PathNode> grid,int x,int y)
   {
      _x = x;
      _y = y;
      _grid = grid;
   }

   

   public void CalculFCost()
   {
      fCost= gCost+hCost;
   }
   public override string ToString()
   {
      return _x+","+_y;
   }
}
