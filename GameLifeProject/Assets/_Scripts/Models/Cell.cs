﻿using UnityEngine;

public class Cell : MonoBehaviour
{
    public CellData cellInfo;
    [SerializeField]private bool _isAlive;
    public bool IsAlive{
        get{return _isAlive;}
        private set{_isAlive = value;}
    }

    [SerializeField]private int _numNeighbours;
    public int NumNeighbours{
        get{return _numNeighbours;}
        set{_numNeighbours = value;}
    }

    public void SetAlive(bool alive){
        _isAlive = alive;
        GetComponent<SpriteRenderer>().enabled = alive;
    }
}
