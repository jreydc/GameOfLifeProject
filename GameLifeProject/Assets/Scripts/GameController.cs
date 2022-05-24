using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]private GridData _gridModel;

    private Cell[,] grid;

    private void Start(){
        _gridModel.GridCreation(10, 10);
        _gridModel.CellManagement(10, 10);
    }

    private void Update(){
        _gridModel.Neighbours();
    }


}
