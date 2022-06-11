using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIModelControls : MonoBehaviour
{
    private InputField _inputWidth;
    private InputField _inputHeight;
    private Button _submit;
    private bool selected;
    [SerializeField]private Dropdown dropdown;
    [SerializeField]private GameObject dropdownPanel;
    [SerializeField]private GameObject gridPanel;
    [SerializeField]private GameObject colorPanel;
    [SerializeField]private GameObject speedPanel;


    private void Start(){ 
        dropdown = GetComponent<Dropdown>();
        dropdown.ClearOptions();
        selected = true;
    }

    private void DropdownItemSelected(Dropdown dropdown){
        int index = dropdown.value;

        if (index == 0){
            gridPanel.SetActive(true);
        }else if (index == 1){
            colorPanel.SetActive(true);
        }else{
            speedPanel.SetActive(true);
        }

    }

    public void GridUIControls(){
        GridData._gridDataInstance._gridAttrib.width = int.Parse(_inputWidth.text);
        GridData._gridDataInstance._gridAttrib.height = int.Parse(_inputHeight.text);
        Debug.Log("GridUIControls"+_inputWidth+_inputHeight);
    }

    public void RandomizedColors(){
        /* Cell cell_instance = Instantiate(Resources.Load("Prefab/Cell", typeof(Cell)), transform.position, Quaternion.identity) as Cell;
        cell_instance.Colors = UnityEngine.Random.ColorHSV(); */
    }

    public void DropdownDisplayEnabled(){
        dropdownPanel.SetActive(true);
    }

    public void DropdownDisplayDisabled(){
        dropdownPanel.SetActive(false);
    }

    public void PanelOnDisplay(){
        if (dropdown.captionText.text == "Grid Dimension"){
            gridPanel.SetActive(selected);
            colorPanel.SetActive(!selected);
            speedPanel.SetActive(!selected);
        }else if (dropdown.captionText.text == "Cell Color"){
            colorPanel.SetActive(true);
            gridPanel.SetActive(false);
            speedPanel.SetActive(false);
        }else if (dropdown.captionText.text == "Speed"){
            speedPanel.SetActive(true);
            colorPanel.SetActive(false);
            gridPanel.SetActive(false);
        }else{
            DisablePanels();
        }
        
    }

    public void EnablePanels(){
            gridPanel.SetActive(selected);
            colorPanel.SetActive(selected);
            speedPanel.SetActive(selected);
    }

    public void DisablePanels(){
            //dropdown.ClearOptions();
            gridPanel.SetActive(false);
            colorPanel.SetActive(false);
            speedPanel.SetActive(false);
    }


}
