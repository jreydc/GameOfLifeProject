using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]private GridData _gridModel;

    private Cell[,] grid;

    private void Start(){
        _gridModel.GridCreation(30, 30);
        _gridModel.CellManagement(30, 30);
    }

    private void Update(){
        _gridModel.Neighbours();
        _gridModel.PopulationControl();
    }


}
