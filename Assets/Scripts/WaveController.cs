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
    private float shieldChance;
    [SerializeField] private bool isPaused = false;

    public AudioSource audioSource;
    public AudioClip[] sfxObstacle;
    public AudioClip[] sfxShield;

    void Update()
    {
        if (isPaused == false && SceneManager.GetActiveScene().name != "GameOver")
        {
            timer += Time.deltaTime;
        if (timer >= interval)
        {
            SetRandomObstacle();
            timer = 0;
        }
        }
    }
    public void SetPause(bool pause)
    {
        isPaused = pause;
        Debug.Log("pausado" + pause);
    }

    void SetRandomObstacle()
    {
        shieldChance = Random.Range(0f, 1f);
        projLocation = Random.Range(0, 2) * 2;
        if (shieldChance >= 0.15f)
        {
            Debug.Log("curou");
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
                            sound = sfxObstacle[0]; //left
                            break;
                        case 2:
                            sound = sfxObstacle[1]; //Right
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
            Debug.Log("p l:" + controls.playerLocation + "obs l " + projLocation);
        }
    }
    void Collect()
    {
        if (projLocation == controls.playerLocation || controls.playerLocation == 1)
        {
            playerController.GainLife();
            Debug.Log("p l:" + controls.playerLocation + "obs l " + projLocation);
        }
    }
}
