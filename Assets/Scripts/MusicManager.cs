using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip music;
    private AudioSource musicSource;
    private int currentClipIndex = 0;

    void Start()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.playOnAwake = false;
        musicSource.volume = 0.5f;
        
       PlayBackgroundMusic();
    }


    public void PlayBackgroundMusic()
    {
        if (music != null)
        {
            musicSource.clip = music;
            musicSource.Play();
        }
    }
}
