using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
   public AudioClip accept;
   public AudioClip audioinit;
     public AudioClip play;
    public AudioSource audioSource;
    public Canvas canvasPause;
    public Canvas canvasUI;
    [SerializeField] private WaveController waveController;
    public int playerLocation = 1;
    public void Start()
    {
        audioSource.PlayOneShot(audioinit);
    }
    void Update()
    {
        Debug.Log(playerLocation);
    }
    public void Audioinit()
    {
        
    }
    public void Left()
    {
        playerLocation = 0;
        //Debug.Log("clicado esquerda");
    }
    public void Middle()
    {
        if (canvasPause != null)
        {
            audioSource.PlayOneShot(accept);
            canvasPause.gameObject.SetActive(true);
            canvasUI.gameObject.SetActive(false);
            waveController.SetPause(true);
            //Debug.Log("canvas criado");
        }
    }
    public void Play()
    {
        audioSource.PlayOneShot(play);
        canvasPause.gameObject.SetActive(false);
        canvasUI.gameObject.SetActive(true);
        waveController.SetPause(false);

    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
    public void Right()
    {
        playerLocation = 2;
        //Debug.Log("clicadp direita");
    
    }
    public void Center()
    {
        playerLocation = 1; 
    }
    public void Retry()
    {
        SceneManager.LoadScene(1);
       // Debug.Log("clicadp retry");
    }
    
}
