using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public SceneFader sceneFader;

    public string menuSceneName = "MainMenu";

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void Retry() {
        Time.timeScale = 1f;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu() {
        Time.timeScale = 1f;
        sceneFader.FadeTo(menuSceneName);
    }
}
