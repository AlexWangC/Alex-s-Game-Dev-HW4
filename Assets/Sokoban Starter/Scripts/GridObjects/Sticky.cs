using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : BetterGridObject
{
    protected override void Start()
    {
        base.Start();
        base.stationary = false;
    }

    public override bool PassiveMove(Vector2Int sourcePosition, Vector2Int moveAmount)
    {
        if (moved) return false;
        var newPos = realPosition + moveAmount;
        var target = GameManager.reference.gridObjects[newPos.y][newPos.x];
        if (target == null || target.PassiveMove(realPosition, moveAmount))
        {

            moved = true;
            BetterGridObject adjacent;
            for (int i = 0; i < 4; i++)
            {
                Vector2Int vector = Vector2Int.zero;

                switch (i)
                {
                    case 0: vector.x = -1; break;
                    case 1: vector.x = 1; break;
                    case 2: vector.y = 1; break;
                    case 3: vector.y = -1; break;
                }
                try
                {
                    adjacent = GameManager.reference.gridObjects[realPosition.y + vector.y][realPosition.x + vector.x];
                    adjacent?.PassiveMove(realPosition, moveAmount);
                }
                catch (System.IndexOutOfRangeException e)
                {
                }
            }
            
            MoveTo(newPos);
            return true;
        }

        return false;
    }
}
