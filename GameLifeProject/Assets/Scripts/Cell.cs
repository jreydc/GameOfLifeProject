using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField]private bool isAlive;
    public bool IsAlive{
        get{return isAlive;}
        private set{isAlive = value;}
    }

    public int numNeighbours;
    /* public int NumNeighbours{
        get{return numNeighbours;}
        set{numNeighbours = value;}
    } */

    public void SetAlive(bool alive){
        isAlive = alive;
        GetComponent<SpriteRenderer>().enabled = alive;
    }
}
