using System;
using UnityEngine;

public class SettingsController : Singleton<SettingsController>
{

    [SerializeField]private GridData _gridModel;
    [SerializeField]private TimerController _timer;
    Color color;
    
    public TimerController TimerInstanstiate{
        get{return _timer;}
        private set{_timer = value;}
    }

    public GridData GridModel{
        get{return _gridModel;}
        private set{_gridModel = value;}
    }
    
    public void SettingsImplementation(int width, int height, float speed){
        _timer.timerInstance.timerSpeed = speed;
         _gridModel.GridCreation(width, height);
        color = _gridModel.SetCellColors();
        _gridModel.CellManagement(width, height, color);
    }

    public void Simulation(){
        _gridModel.Neighbours();
        _gridModel.PopulationControl();
        _gridModel.CellCounter();
    }

    public int SetCellAliveDisplay(){
        int cellAlive = 0;
        cellAlive = _gridModel.CellAlive;
        return cellAlive;
    }
    
    public int SetCellDeadDisplay(){
        int cellDead = 0;
        cellDead = _gridModel.CellDead;
        return cellDead;
    }
}
