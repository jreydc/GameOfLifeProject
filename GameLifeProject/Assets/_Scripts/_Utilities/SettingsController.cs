using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : Singleton<SettingsController>
{
    
    [SerializeField]private TimerController _timer;
    [SerializeField]private GridData _gridModel;
    [SerializeField]private InputField _inputWidth;
    [SerializeField]private InputField _inputHeight;
    [SerializeField]private InputField _inputSpeed;
    
    public TimerController TimerInstanstiate{
        get{return _timer;}
        private set{_timer = value;}
    }

    private int width;
    private int height;
    private float speed;

    public void SetGridSettings(){
        GameController._SingleInstance.UpdateState(GameController.States.SIMULATE);
        width = System.Int32.Parse(_inputWidth.text);
        height = System.Int32.Parse(_inputHeight.text);
        speed = float.Parse(_inputSpeed.text);

        /* _gridModel._gridAttrib.width = width;
        _gridModel._gridAttrib.height = height; */
        _timer.timerInstance.timerSpeed = speed;
        
        _gridModel.GridCreation(width, height);
        _gridModel.CellManagement(width, height);
        
        //_gridModel._gridAttrib.defaultHeight = 40; //default size
        //_gridModel._gridAttrib.defaultWidth = 40;//default size
        //_gridModel._gridAttrib.width = _gridModel._gridAttrib.defaultWidth;
        //_gridModel._gridAttrib.height = _gridModel._gridAttrib.defaultHeight; 

        Debug.Log("GridUIControls"+_inputWidth.text+_inputHeight.text);
    }

    public void SettingsImplementation(){
        _gridModel.Neighbours();
        _gridModel.PopulationControl();
    }

    public void SetCellColors(){
        _gridModel.RandomizedColors();
    }
}
