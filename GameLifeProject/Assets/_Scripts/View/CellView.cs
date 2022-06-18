using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    [SerializeField]private Text cellAliveText;
    [SerializeField]private Text cellDeadText;

    private void Start() {
        cellAliveText.text = "";
        cellDeadText.text = "";
    }

    private void Update() {
        cellAliveText.text = SettingsController._SingleInstance.SetCellAliveDisplay().ToString();
        cellDeadText.text = SettingsController._SingleInstance.SetCellDeadDisplay().ToString();
    }
}
