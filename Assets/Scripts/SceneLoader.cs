using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void PlayGame()
    {
<<<<<<< Updated upstream
        Time.timeScale = 1f;    
=======
        Time.timeScale = 1f;
>>>>>>> Stashed changes
        SceneManager.LoadScene("City");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("eh");
    }
}
