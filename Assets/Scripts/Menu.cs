using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
     
    public void NextScene()
    {
        //audioSource.PlayOneShot(accept);
        
        int cSindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(cSindex + 1);
    }
    public void PreviousScene()
    {
        int cSindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(cSindex - 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
