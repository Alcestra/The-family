using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1f;    
        SceneManager.LoadScene("City");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("eh");
    }
}
