using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GridModel _gridModel;

    private Cell[,] grid;

    private void Start(){
        _gridModel.GridCreation();
        _gridModel.CellManagement();
    }


}
