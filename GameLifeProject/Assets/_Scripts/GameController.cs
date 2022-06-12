﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]private GridData _gridModel;
    public UIModelControls _uiControl;

    [SerializeField]private Timer _timer;

    private Cell[,] grid;

    enum Choices{ GridDimension, Colors, Speed };

    enum Levels{};
    private string _currentLevelName = string.Empty;

    private void Awake() {
        _timer.time = 0f;
        _timer.timerSpeed = 0.1f;
        _timer.time_scale = 1f;

        _gridModel._gridAttrib.defaultHeight = 40; //default size
        _gridModel._gridAttrib.defaultWidth = 40;//default size
        _gridModel._gridAttrib.width = _gridModel._gridAttrib.defaultWidth;
        _gridModel._gridAttrib.height = _gridModel._gridAttrib.defaultHeight;    
    }

    private void Start(){
        LoadLevel("StartScene");
        _gridModel.GridCreation(_gridModel._gridAttrib.width, _gridModel._gridAttrib.height);
        _gridModel.CellManagement(_gridModel._gridAttrib.width, _gridModel._gridAttrib.height);
    }

    private void Update(){
        if (_timer.time >= _timer.timerSpeed){
            _timer.time = 0f;
            _gridModel.Neighbours();
            _gridModel.PopulationControl();
        }else{
            _timer.time += Time.deltaTime;
        }
        
    }

    public void SetGridDimension(){
        _uiControl.GridUIControls();
    }

    public void SetCellColors(){
        _uiControl.RandomizedColors();
    }

   public void LoadLevel(string levelName)
    {
        //_timer.time_scale = 0f;
        Time.timeScale = 0f;
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        _currentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        SceneManager.UnloadSceneAsync(levelName);
    }

}
