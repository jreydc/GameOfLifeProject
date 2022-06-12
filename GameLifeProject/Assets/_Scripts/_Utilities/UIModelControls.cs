using UnityEngine;
using UnityEngine.UI;

public class UIModelControls : MonoBehaviour
{
    [SerializeField]private GridData _gridModel;
    [SerializeField]private InputField _inputWidth;
    [SerializeField]private InputField _inputHeight;
    [SerializeField]private InputField _inputSpeed;


    private Button _submit;

    public void GridUIControls(){
        _gridModel._gridAttrib.width = int.Parse(_inputWidth.text);
        _gridModel._gridAttrib.height = int.Parse(_inputHeight.text);

        //_gridModel._gridAttrib.defaultHeight = 40; //default size
        //_gridModel._gridAttrib.defaultWidth = 40;//default size
        //_gridModel._gridAttrib.width = _gridModel._gridAttrib.defaultWidth;
        //_gridModel._gridAttrib.height = _gridModel._gridAttrib.defaultHeight; 

        Debug.Log("GridUIControls"+_inputWidth+_inputHeight);
    }

    public void RandomizedColors(){
        /* Cell cell_instance = Instantiate(Resources.Load("Prefab/Cell", typeof(Cell)), transform.position, Quaternion.identity) as Cell;
        cell_instance.Colors = UnityEngine.Random.ColorHSV(); */
    }

    public void SetSimulationSpeed(){
        
    }

    public void SetGridDimension(){

    }

}
