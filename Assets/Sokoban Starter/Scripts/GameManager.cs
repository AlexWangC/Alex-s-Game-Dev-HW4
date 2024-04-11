using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _reference;
    public static GameManager reference => _reference;
    
    private BetterGridObject[][] _gridObjects;
    public BetterGridObject[][] gridObjects {
        get
        {
            if (_gridObjects != null) return _gridObjects;
            
            var size = GridMaker.reference.dimensions;
            _gridObjects = new BetterGridObject[(int)size.y][];
            for (int i = 0; i < _gridObjects.Length; i++)
                _gridObjects[i] = new BetterGridObject[(int)size.x];
            return _gridObjects;
        }
    }

    private void Awake()
    {
        _reference = this;
        print("rows:" + gridObjects.Length);
        print("cols:" + gridObjects[0].Length);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            for (int i = 0; i < gridObjects.Length; i ++)
                for (int j = 0; j < gridObjects[0].Length; j++)
                    if (gridObjects[i][j] != null)
                        print($"{j},{i}");
    }
}
