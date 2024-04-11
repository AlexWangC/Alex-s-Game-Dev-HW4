using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            PlayerMove(Vector2Int.down);
        if (Input.GetKeyDown(KeyCode.A))
            PlayerMove(Vector2Int.left);
        if (Input.GetKeyDown(KeyCode.S))
            PlayerMove(Vector2Int.up);
        if (Input.GetKeyDown(KeyCode.D))
            PlayerMove(Vector2Int.right);
    }

    private void PlayerMove(Vector2Int move)
    {
        var newPos = player.realPosition + move;
        if (newPos.x < 0 || newPos.y < 0 ||
            newPos.x > GridMaker.reference.dimensions.x ||
            newPos.y > GridMaker.reference.dimensions.y)
            return;
        
        var gridObject = GameManager.reference.gridObjects[newPos.y][newPos.x];
        if (gridObject != null)
        {
            if (gridObject.stationary)
                return;
            if (!gridObject.PassiveMove(player.realPosition, move))
                return;
        }

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
                adjacent = GameManager.reference.gridObjects[player.realPosition.y + vector.y][player.realPosition.x + vector.x];
                adjacent?.PassiveMove(player.realPosition, move);
            }
            catch (IndexOutOfRangeException e)
            {
            }
        }

        player.MoveTo(newPos);
    }
}
