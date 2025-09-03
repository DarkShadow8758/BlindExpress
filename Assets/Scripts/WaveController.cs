using UnityEngine;

public class WaveController : MonoBehaviour
{
    public float interval = 6f;
    public int obstacleLocation;
    [SerializeField] private Controls controls;
    [SerializeField] private PlayerController playerController;

    private float timer = 0f;
    private float timerTrigger;

    public AudioSource audioSource;
    public AudioClip[] sfx;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            SetRandomObstacle();
            timer = 0;
        }
    }

    void SetRandomObstacle()
    {
        obstacleLocation = Random.Range(0, 2) * 2;
        //Debug.Log("Setando: " + obstacleLocation); 
        PlaySFX(obstacleLocation);
    }

    public void PlaySFX(int side)
    {
        if (!audioSource.isPlaying)
        {
            var sound = sfx[0];
            switch (side)
            {
                case 0:
                    sound = sfx[0]; //left
                    break;
                case 2:
                    sound = sfx[1]; //Right
                    break;
            }
            audioSource.PlayOneShot(sound);
            timerTrigger = sound.length * 0.5f;
            Debug.Log("Startou corotina sendo som: " + sound + " tt: " + timerTrigger + "side: " + side);
            StartCoroutine(WaitSfxImpact(timerTrigger));

        }
    }

    System.Collections.IEnumerator WaitSfxImpact(float time)
    {
        yield return new WaitForSeconds(time);
        Impact();
    }

    void Impact()
    {
        if (obstacleLocation == controls.playerLocation || controls.playerLocation == 1)
        {
            playerController.Damage();
            Debug.Log("p l:" + controls.playerLocation + "obs l " + obstacleLocation);
        }
    }
}
