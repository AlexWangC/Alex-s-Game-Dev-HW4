using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BetterGridObject : GridObject
{
    public Vector2Int realPosition => gridPosition - Vector2Int.one;
    protected bool moved = false;

    private static List<BetterGridObject> list = new List<BetterGridObject>();
    
    public bool stationary { get; protected set; }
    protected virtual void Start()
    {
        GameManager.reference.gridObjects[realPosition.y][realPosition.x] = this;
        list.Add(this);
    }

    private void LateUpdate()
    {
        moved = false;
    }

    public void MoveTo(Vector2Int newPosition)
    {
        if (newPosition.x < 0 || newPosition.y < 0 ||
            newPosition.x > GridMaker.reference.dimensions.x ||
            newPosition.y > GridMaker.reference.dimensions.y)
            return;
        
        GameManager.reference.gridObjects[realPosition.y][realPosition.x] = null;
        GameManager.reference.gridObjects[newPosition.y][newPosition.x] = this;
        gridPosition = newPosition + Vector2Int.one;
    }

    public abstract bool PassiveMove(Vector2Int sourcePosition, Vector2Int moveAmount);
}
