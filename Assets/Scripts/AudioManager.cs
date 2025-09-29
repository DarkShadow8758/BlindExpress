using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Array de áudios a serem tocados em sequência
    public AudioClip[] audioClips;
    public AudioClip music;
    private AudioSource audioSource;
    private AudioSource musicSource;
    private int currentClipIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Criar um AudioSource separado para música de fundo
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.playOnAwake = false;
        musicSource.volume = 0.5f; // ajuste o volume se quiser
        
       PlayBackgroundMusic();
        PlayNextClip();
    }

    void Update()
    {
        audioSource.volume = 50f;
        // Quando o áudio terminar, toca o próximo
    
        if (!audioSource.isPlaying && audioClips.Length > 0 && currentClipIndex < audioClips.Length-1)
        {
            PlayNextClip();
        }
    }

    void PlayNextClip()
    {
        if (audioClips.Length == 0) return;
        audioSource.clip = audioClips[currentClipIndex];

        audioSource.Play();
        if (currentClipIndex < audioClips.Length - 1)
        {
            currentClipIndex++;
        }
        
    }

    // Toca a música de fundo em loop
    public void PlayBackgroundMusic()
    {
        if (music != null)
        {
            musicSource.clip = music;
            musicSource.Play();
        }
    }
}
