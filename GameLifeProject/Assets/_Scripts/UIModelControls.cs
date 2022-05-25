using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIModelControls : MonoBehaviour
{
    [SerializeField]private InputField _inputWidth;
    [SerializeField]private InputField _inputHeight;
    [SerializeField]private Button _submit;

    [SerializeField]private Dropdown dropdown;
    [SerializeField]private GameObject gridPanel;
    [SerializeField]private GameObject colorPanel;
    [SerializeField]private GameObject speedPanel;


    private void Start(){
        dropdown.GetComponent<Dropdown>();
        dropdown.onValueChanged.AddListener(DropdownItemSelected(dropdown));
        _submit.onClick.AddListener(GridUIControls);
    }

    private void DropdownItemSelected(Dropdown dropdown){
        int index = dropdown.value;

        if (index == 0){
            gridPanel.setActive(true);
        }else if (index == 1){
            colorPanel.setActive(true);
        }else{
            speedPanel.setActive(true);
        }
    }

    public void GridUIControls(){
        GridData._gridDataInstance._gridAttrib.width = int.Parse(_inputWidth.text);
        GridData._gridDataInstance._gridAttrib.height = int.Parse(_inputHeight.text);
        Debug.Log("GridUIControls"+_inputWidth+_inputHeight);
    }

    public void RandomizedColors(){
        Cell cell_instance = Instantiate(Resources.Load("Prefab/Cell", typeof(Cell)), transform.position, Quaternion.identity) as Cell;
        //cell_instance.SpriteRenderer.Colors = UnityEngine.Random.ColorHSV();
    }

    
}
