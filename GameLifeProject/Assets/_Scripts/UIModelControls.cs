using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIModelControls : MonoBehaviour
{
    [SerializeField]private InputField _inputWidth;
    [SerializeField]private InputField _inputHeight;
    [SerializeField]private Button _submit;


    public void GridUIControls(){
        GridData._gridDataInstance._gridAttrib.width = int.Parse(_inputWidth.text);
        GridData._gridDataInstance._gridAttrib.height = int.Parse(_inputHeight.text);
    }
}
