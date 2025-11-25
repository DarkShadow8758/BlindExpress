using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveController : MonoBehaviour
{
    public float interval = 6f;
    public int projLocation;
    [SerializeField] private Controls controls;
    [SerializeField] private PlayerController playerController;

    private float timer = 0f;
    private float timerTrigger;
    [Header("Play timer")]
    [Tooltip("Tempo em segundos até avançar para a próxima cena (por padrão 120 = 2 minutos)")]
    public float playDuration = 120f;
    private float playTimer = 0f;
    private bool hasTimedOut = false;
    [Range(0f, 1f)]
    [SerializeField] private float shieldChance;
    [SerializeField] private bool isPaused = false;

    public AudioSource audioSource;
    public AudioClip[] sfxObstacle;
    public AudioClip[] sfxShield;

    void Update()
    {
        if (isPaused == false && SceneManager.GetActiveScene().name != "GameOver")
        {
            timer += Time.deltaTime;
            if (!hasTimedOut)
            {
                playTimer += Time.deltaTime;
                if (playTimer >= playDuration)
                {
                    hasTimedOut = true;
                    GoToNextScene();
                }
            }
        if (timer >= interval)
        {
            SetRandomObstacle();
            timer = 0;
        }
        }
    }

    void GoToNextScene()
    {
        int next = 3;
        SceneManager.LoadScene(next);
    }
    public void SetPause(bool pause)
    {
        isPaused = pause;
    }

    void SetRandomObstacle()
    {

        projLocation = Random.Range(0, 2) * 2;
        
        if (Random.Range(0f, 1f) <= shieldChance)
        {
            //Debug.Log("curou");
            PlaySFX(projLocation, "shield");
        }
        else
        {
            PlaySFX(projLocation, "obstacle");
        }
        
        //Debug.Log("Setando: " + obstacleLocation); 
        
    }

    public void PlaySFX(int side, string type)
    { 
        if (!audioSource.isPlaying)
        {
            var sound = sfxObstacle[0];
            switch (type)
            {
                case "obstacle":
                    switch (side)
                    {
                        case 0:
                            sound = sfxObstacle[0]; // esquerda
                            break;
                        case 2:
                            sound = sfxObstacle[1]; //direita
                            break;
                    }
                    audioSource.PlayOneShot(sound);
                    timerTrigger = sound.length * 0.5f;
                    // Debug.Log("Startou corotina sendo som: " + sound + " tt: " + timerTrigger + "side: " + side);
                    StartCoroutine(WaitSfxImpact(timerTrigger, type));
                    break;
                case "shield":
                    switch (side)
                    {
                        case 0:
                            sound = sfxShield[0];
                            break;
                        case 2:
                            sound = sfxShield[1]; 
                            break;
                    }
                    audioSource.PlayOneShot(sound);
                    timerTrigger = sound.length * 0.5f; 
                    StartCoroutine(WaitSfxImpact(timerTrigger, type));
                    break;
            }
        }
    }

    System.Collections.IEnumerator WaitSfxImpact(float time, string type)
    {
        yield return new WaitForSeconds(time);
        switch (type)
        {
            case "obstacle":
                Impact();
            break;
            case "shield":
                Collect();
            break;
        }
        
    }

    void Impact()
    {
        if (projLocation == controls.playerLocation || controls.playerLocation == 1)
        {
            playerController.Damage();
            //Debug.Log("player em: " + controls.playerLocation + "projetil em: " + projLocation);
        }
    }
    void Collect()
    {
        if (projLocation == controls.playerLocation)
        {
            playerController.GainLife();
            //Debug.Log("player em: " + controls.playerLocation + "projetil em: " + projLocation);
        }
    }
}
