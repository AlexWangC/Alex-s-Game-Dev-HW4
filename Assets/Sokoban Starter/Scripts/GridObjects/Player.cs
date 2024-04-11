using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BetterGridObject
{
    public override bool PassiveMove(Vector2Int sourcePosition, Vector2Int moveAmount)
    {
        return false;
    }
}
