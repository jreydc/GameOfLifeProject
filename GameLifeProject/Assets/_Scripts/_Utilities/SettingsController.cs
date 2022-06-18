using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : Singleton<SettingsController>
{

    [SerializeField]private GridData _gridModel;
    private TimerController _timer;
    Color color;
    
    public TimerController TimerInstanstiate{
        get{return _timer;}
        private set{_timer = value;}
    }
    
    public void SettingsImplementation(int width, int height, float speed){
         _gridModel.GridCreation(width, height);
        color = _gridModel.SetCellColors();
        _gridModel.CellManagement(width, height, color);
        _gridModel.Neighbours();
        _gridModel.PopulationControl();
    }

    
}
