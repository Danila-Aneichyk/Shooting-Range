using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseScreen : MonoBehaviour
{
    [SerializeField] private int _sceneIndex;

    protected void MoveToNextScene()
    {
        SceneManager.LoadScene(_sceneIndex);
        Time.timeScale = 1; 
    }

    protected void Exit()
    {
        Application.Quit();
    }

    protected void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1; 
    }
}
