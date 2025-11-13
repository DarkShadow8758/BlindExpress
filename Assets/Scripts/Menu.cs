using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioClip[] sfx;
    public AudioSource audioSource;
    public void NextScene()
    {
        audioSource.PlayOneShot(sfx[1]);
        
        int cSindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(cSindex + 1);
    }
    public void PreviousScene()
    {
        audioSource.PlayOneShot(sfx[0]);
        int cSindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(cSindex - 1);
    }
    public void QuitGame()
    {
        audioSource.PlayOneShot(sfx[0]);
        Application.Quit();
    }
}
