using UnityEngine;

public class WaveController : MonoBehaviour
{
    public float interval = 5f;
    public int obstacleLocation;
    [SerializeField] private Controls controls;
    [SerializeField] private PlayerController playerController;

    private float timer = 0f;

    public AudioSource audioSource;
    public AudioClip sfx;

    // -1 = totalmente no lado esquerdo
    //  1 = totalmente no lado direito
    //  0 = centralizado
    public float pan = -1f; 
    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            SetRandomObstacle();

            if (timer >= interval+1.5f){
            
            if (obstacleLocation == controls.playerLocation || controls.playerLocation == 1)
            {
                playerController.Damage();
            }
            timer = 0f;}
        }
    }

    public void PlaySFX(int pan)
    {
        audioSource.panStereo = pan;
        audioSource.PlayOneShot(sfx);
    }

    void SetRandomObstacle()
    {
        obstacleLocation = Random.Range(0, 2)*2;
        PlaySFX(obstacleLocation-1);
        Debug.Log("Player location: " + controls.playerLocation + " Obstacle Location: " + obstacleLocation);
    }
}
