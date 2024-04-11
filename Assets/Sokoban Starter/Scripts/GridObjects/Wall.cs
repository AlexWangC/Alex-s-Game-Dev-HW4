using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : BetterGridObject
{
    protected override void Start()
    {
        base.Start();
        base.stationary = true;
    }

    public override bool PassiveMove(Vector2Int sourcePosition, Vector2Int moveAmount)
    {
        return false;
    }
}
