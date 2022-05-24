using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridData : MonoBehaviour
{
    public GridAttrib _gridAttrib;
public Cell[,] grid;
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



    public void GridCreation(){

    }

    public void CellManagement(){

    }
}
