using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : Singleton<SettingsController>
{
    
    private TimerController _timer;
    
    
    public TimerController TimerInstanstiate{
        get{return _timer;}
        private set{_timer = value;}
    }
    
    public void SettingsImplementation(int width, int height, Color color){
         _gridModel.GridCreation(width, height);
        //SetCellColors();
        _gridModel.CellManagement(width, height, color);
        _gridModel.Neighbours();
        _gridModel.PopulationControl();
    }

    
}
