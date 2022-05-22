using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField]private bool _isAlive;
    public bool IsAlive{
        get{return _isAlive;}
        private set{_isAlive = value;}
    }

    private int _numNeighbours = 0;
    public int NumNeighbours{
        get{return _numNeighbours;}
        set{_numNeighbours = value;}
    }

    public void SetAlive(bool alive){
        _isAlive = alive;
        GetComponent<SpriteRenderer>().enabled = alive;
    }
}
