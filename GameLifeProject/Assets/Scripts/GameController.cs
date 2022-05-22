using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GridSystem _gridManaged;

    [SerializeField]private int x;
    [SerializeField]private int y;

    private void Start(){
        _gridManaged.CreateEmptyGrid(x, y);
    }


}
