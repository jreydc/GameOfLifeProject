using UnityEngine;


public class GameController : MonoBehaviour
{
    [SerializeField]private GridData _gridModel;
    [SerializeField]private LoadingLevelController _loading;
    public UIModelControls _uiControl;

    [SerializeField]private TimerController _timer;

    private Cell[,] grid;

    enum Choices{ GridDimension, Colors, Speed };


    private void Awake() {
        _timer.TimerInitializations();
        _gridModel._gridAttrib.defaultHeight = 40; //default size
        _gridModel._gridAttrib.defaultWidth = 40;//default size
        _gridModel._gridAttrib.width = _gridModel._gridAttrib.defaultWidth;
        _gridModel._gridAttrib.height = _gridModel._gridAttrib.defaultHeight;    
    }

    private void Start(){
        _loading.LoadLevel("StartScene");
        _gridModel.GridCreation(_gridModel._gridAttrib.width, _gridModel._gridAttrib.height);
        _gridModel.CellManagement(_gridModel._gridAttrib.width, _gridModel._gridAttrib.height);
    }

    private void Update(){
        if (_timer.timerInstance.time >= _timer.timerInstance.timerSpeed){
            _timer.timerInstance.time = 0f;
            _gridModel.Neighbours();
            _gridModel.PopulationControl();
        }else{
            _timer.timerInstance.time += Time.deltaTime;
        }
        
    }

    public void SetGridDimension(){
        _uiControl.GridUIControls();
    }

    public void SetCellColors(){
        _uiControl.RandomizedColors();
    }
}
