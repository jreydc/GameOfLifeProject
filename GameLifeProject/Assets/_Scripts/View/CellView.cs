using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    [SerializeField]private Text cellAliveText;
    [SerializeField]private Text cellDeadText;

    private void Start() {
        cellAliveText.text = string.Empty;
        cellDeadText.text = string.Empty;
    }

    private void Update() {
        if (!(GameController._SingleInstance.CurrentState == GameController.States.SIMULATE)) return;
        cellAliveText.text = SettingsController._SingleInstance.SetCellAliveDisplay().ToString();
        cellDeadText.text = SettingsController._SingleInstance.SetCellDeadDisplay().ToString();
    }
}
