using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]private GridData _gridModel;
    public UIModelControls _uiControl;

    private Cell[,] grid;

    enum Choices{ GridDimension, Colors, Speed };
    private string _currentLevelName = string.Empty;

    private void Awake() {
        _gridModel._gridAttrib.defaultHeight = 40; //default size
        _gridModel._gridAttrib.defaultWidth = 40;//default size
        _gridModel._gridAttrib.width = _gridModel._gridAttrib.defaultWidth;
        _gridModel._gridAttrib.height = _gridModel._gridAttrib.defaultHeight;    
    }

    private void Start(){
        SceneManager.LoadSceneAsync("StartScene", LoadSceneMode.Additive);
        _gridModel.GridCreation(_gridModel._gridAttrib.width, _gridModel._gridAttrib.height);
        _gridModel.CellManagement(_gridModel._gridAttrib.width, _gridModel._gridAttrib.height);
    }

    private void Update(){
        _gridModel.Neighbours();
        _gridModel.PopulationControl();
    }

    public void SetGridDimension(){
        _uiControl.GridUIControls();
    }

    public void SetCellColors(){
        _uiControl.RandomizedColors();
    }

   public void LoadLevel(string levelName)
    {
        SceneManager.LoadSceneAsync(levelName);
        _currentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        SceneManager.UnloadSceneAsync(levelName);
    }

}
