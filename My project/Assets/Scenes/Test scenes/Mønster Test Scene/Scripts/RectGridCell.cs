using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAI.PathFinding;

public class RectGridCell : Node<Vector2Int>
{
    public bool IsWalkable { get; set; }

    private RectGrid_viz mRectGrid_Viz;


    public RectGridCell(RectGrid_viz gridMap, Vector2Int value)
        : base(value)
    {
        mRectGrid_Viz = gridMap;

        IsWalkable = true;
    }

    public override List<Node<Vector2Int>> GetNeighbours()
    {
        return mRectGrid_Viz.GetNeighbourCells(this);
    }
}
