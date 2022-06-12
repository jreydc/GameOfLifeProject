using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingLevelController : ScriptableObject
{
    private string _currentLevelName = string.Empty;
    public void LoadLevel(string levelName)
    {
        //_timer.time_scale = 0f;
        Time.timeScale = 0f;
        SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        _currentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync(levelName);
    }
}
