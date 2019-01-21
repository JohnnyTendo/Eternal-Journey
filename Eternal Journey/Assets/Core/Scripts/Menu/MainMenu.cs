using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void NewGame(bool isStarting) {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
    }

    public void LoadGame(bool isLoading) {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Single);
    }

    public void OptionsMenu(bool isOptimizing) {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    public void QuitGame(bool isQuitting) {
        Application.Quit();
    }
}