using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("levelOne");
    }

    public void LoadVictoryScreen()
    {
        SceneManager.LoadScene("victoryScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
