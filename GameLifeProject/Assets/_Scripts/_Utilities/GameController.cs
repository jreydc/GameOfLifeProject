using UnityEngine;


public class GameController : MonoBehaviour
{
    private GameController _instance;
    [SerializeField]private GridData _gridModel;
    [SerializeField]private LoadingLevelController _loading;
    [SerializeField]private UIModelControls _uiControl;

    [SerializeField]private TimerController _timer;

    private Cell[,] grid;

    enum Choices{ GridDimension, Colors, Speed };

    protected virtual void Awake() {
        if(_instance == null){
           //Debug.Log(typeof(T).ToString() + " is NULL.");
            _instance = this;
            DontDestroyOnLoad(transform.root.gameObject);
        }
        else
        {
            Destroy(gameObject);
            //Debug.Log(typeof(T).ToString() + " has tried to instantiate again!");
        }
    }

    private void Start(){
        _timer.TimerInitializations();
        _gridModel._gridAttrib.defaultHeight = 40; //default size
        _gridModel._gridAttrib.defaultWidth = 40;//default size
        _gridModel._gridAttrib.width = _gridModel._gridAttrib.defaultWidth;
        _gridModel._gridAttrib.height = _gridModel._gridAttrib.defaultHeight;    
        
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
