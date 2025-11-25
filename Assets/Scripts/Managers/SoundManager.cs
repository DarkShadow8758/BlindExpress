using System;
using System.Collections;
using UnityEngine;

public enum SoundType
{
    DIALOGUE_MENU,
    DIALOGUE_END,
    DIALOGUE_TUTORIAL,
    SFX
}
[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundList[] soundList;
    private static SoundManager instance;
    private AudioSource audioSource;
    public static event Action OnAudioFinished;

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }
   
    public static void PlaySound(SoundType sound, float vol = 1)
    {
        AudioClip[] clips = instance.soundList[(int)sound].Sounds;
        if (clips == null || clips.Length == 0) return;
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.PlaySequence(clips, vol));     
    }
    private System.Collections.IEnumerator PlaySequence(AudioClip[] clips, float vol)
    {
        foreach (var clip in clips)
        {
            if (clip == null) continue;

            instance.audioSource.PlayOneShot(clip, vol);

            yield return new WaitForSeconds(clip.length);
        }
    }
    public static void PlayTutorialClip(AudioClip clip, Action onFinish, float volume = 1)
    {
        //Debug.Log("play tutorial clip");
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.PlayTutorialRoutine(clip, onFinish, volume));
    }

    private IEnumerator PlayTutorialRoutine(AudioClip clip, Action onFinish, float volume)
    {
        //Debug.Log("play tutorial routine" + clip);
        instance.audioSource.PlayOneShot(clip, volume);
        yield return new WaitForSeconds(clip.length);

        onFinish?.Invoke();
    }

#if UNITY_EDITOR
    void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList, names.Length);
        for (int i = 0; i < soundList.Length; i++)
            soundList[i].name = names[i];
    }
#endif
}

[Serializable]
public struct SoundList
{
    public AudioClip[] Sounds {get => sounds;}
    [HideInInspector] public string name;
    [SerializeField] private AudioClip[] sounds;
}