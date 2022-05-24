using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GridData _gridModel;

    private Cell[,] grid;

    void Start(){
        _gridModel.GridCreation();
        _gridModel.CellManagement();
    }


}
