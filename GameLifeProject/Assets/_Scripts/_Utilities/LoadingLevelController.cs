using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadingLevelController : MonoBehaviour
{

    private string _currentLevelName = string.Empty;
    public void LoadLevel(string levelName)
    {
        GameController._SingleInstance.UpdateState(GameController.States.END);
        //_timer.time_scale = 0f;
        Time.timeScale = 0f;
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        _currentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        GameController._SingleInstance.UpdateState(GameController.States.SIMULATE);
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync(levelName);
    }
}
