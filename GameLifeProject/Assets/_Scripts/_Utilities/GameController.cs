using UnityEngine;


public class GameController : Singleton<GameController>
{
    [SerializeField]private GridData _gridModel;
    [SerializeField]private LoadingLevelController _loading;
    [SerializeField]private UIModelControls _uiControl;

    

    private Cell[,] grid;

    public enum States{ START, SIMULATE, END };

    States _currentState = States.START;
    public States CurrentState{
        get { return _currentState; }
        private set { _currentState = value; }
    }

    private void Start(){

        SetGameSettings();
        _loading.LoadLevel("StartScene");
        
    }

    public void SetGameSettings(){
        //_uiControl.GridUIControls();
    }

    public void SetCellColors(){
        //_uiControl.RandomizedColors();
    }

    public void UpdateState(States state)
    {
        States previousState = _currentState;
        _currentState = state;

        switch (_currentState)
        {
            case States.START:
                break;

            case States.SIMULATE:
                break;

            case States.END:
                break;

            default:
                break;
        }
    }

}
