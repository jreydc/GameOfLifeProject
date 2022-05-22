using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = Unity.Mathematics.Random;

[System.Serializable]
public class GridData
{
    public GridAttrib _gridAttrib;
    public int CellCount => _gridAttrib.x * _gridAttrib.y;
    private static GridData _current;
    public static GridData GridInstance
    {
        get
        {
            if (_current == null)
            {
                _current = new GridData();
            }

            return _current;
        }
    }
}
