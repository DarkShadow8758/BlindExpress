using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    [SerializeField] private Image btnLeft;
    [SerializeField] private Image btnRight;
   public AudioClip accept;
   public AudioClip audioinit;
     public AudioClip play;
    public AudioSource audioSource;
    public Canvas canvasPause;
    public Canvas canvasUI;
    [SerializeField] private WaveController waveController;
    public int playerLocation = 1;


    //public void OnLeft(InputValue value)
    /* public void OnLeft(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            btnLeft.color = Color.blue;
            playerLocation = 0;
        }
        else
        {
            btnLeft.color = Color.white;
            playerLocation = 1;
        }

    } */
    /* public void OnMiddle(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            btnLeft.color = Color.green;
            
        }
        else
        {
            btnLeft.color = Color.white;
        }
    } */
    /* public void OnRight(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            btnRight.color = Color.red;
            playerLocation = 2;
        }
        else
        {
            btnRight.color = Color.white;
            playerLocation = 1;
        }
    } */
    public void Start()
    {
        audioSource.PlayOneShot(audioinit);
    }
    public void Audioinit()
    {
        
    }
    public void Left()
    {
        playerLocation = 0;
    }
    public void Middle()
    {
        if (canvasPause != null)
        {
            audioSource.PlayOneShot(accept);
            canvasPause.gameObject.SetActive(true);
            canvasUI.gameObject.SetActive(false);
            waveController.SetPause(true);
            Debug.Log("canvas criado");
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
    }
    public void Center()
    {
        playerLocation = 1;
    }
    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
    
}
