using UnityEngine;


public class UIModelControls : MonoBehaviour
{
    private void Update(){
        if (!(GameController._SingleInstance.CurrentState == GameController.States.SIMULATE)) return;
        if (SettingsController._SingleInstance.TimerInstanstiate.timerInstance.time >= SettingsController._SingleInstance.TimerInstanstiate.timerInstance.timerSpeed){
            SettingsController._SingleInstance.TimerInstanstiate.timerInstance.time = 0f;
            SettingsController._SingleInstance.Simulation();
        }else{
            SettingsController._SingleInstance.TimerInstanstiate.timerInstance.time += Time.deltaTime;
        }
        
    }
}
