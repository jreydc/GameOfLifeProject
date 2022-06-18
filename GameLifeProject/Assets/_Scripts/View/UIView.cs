using UnityEngine;
using UnityEngine.UI;

public class UIView : MonoBehaviour
{
    //[SerializeField]private TimerController _timer;
    //private SettingsController _setControls;
    [SerializeField]private InputField _inputWidth;
    [SerializeField]private InputField _inputHeight;
    [SerializeField]private InputField _inputSpeed;
    
    private int width;
    private int height;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetGridSettings(){
        GameController._SingleInstance.UpdateState(GameController.States.SIMULATE);
        width = System.Int32.Parse(_inputWidth.text);
        height = System.Int32.Parse(_inputHeight.text);
        speed = float.Parse(_inputSpeed.text);

        /* _gridModel._gridAttrib.width = width;
        _gridModel._gridAttrib.height = height; */
        
        SettingsController._SingleInstance.SettingsImplementation(width, height, speed);
    }
}
