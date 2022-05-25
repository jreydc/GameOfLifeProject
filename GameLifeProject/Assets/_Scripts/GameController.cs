using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]private GridData _gridModel;
    public UIModelControls _uiControl;

    private Cell[,] grid;

    private void Start(){
        _gridModel._gridAttrib.defaultHeight = 30;
        _gridModel._gridAttrib.defaultWidth = 30;
        _gridModel._gridAttrib.width = _gridModel._gridAttrib.defaultWidth;
        _gridModel._gridAttrib.height = _gridModel._gridAttrib.defaultHeight;

        _gridModel.GridCreation(_gridModel._gridAttrib.width, _gridModel._gridAttrib.height);
        _gridModel.CellManagement(_gridModel._gridAttrib.width, _gridModel._gridAttrib.height);
    }

    private void Update(){
        _gridModel.Neighbours();
        //_gridModel.PopulationControl();
    }

    public void SetGridDimension(){
        _uiControl.GridUIControls();
    }

}
