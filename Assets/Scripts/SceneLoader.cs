using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("City");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("eh");
    }
}
