using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int life = 3;
    [SerializeField] private TextMeshProUGUI tmpLife;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] impactAudios;
    void Start()
    {
        tmpLife.text = life.ToString();
    }
    public void Damage()
    {
        life--;
        tmpLife.text = life.ToString();
    // aqui estou chamando a vibrção no mobile, ja que no pc e editor é retornado erro
    #if UNITY_ANDROID || UNITY_IOS
        Handheld.Vibrate();
    #endif
        var i = Random.Range(0, 2);
        audioSource.Stop();
        audioSource.PlayOneShot(impactAudios[i]);
        if (life <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
    public void GainLife()
    {
        life += 1;
        tmpLife.text = life.ToString();
        #if UNITY_ANDROID || UNITY_IOS
                Handheld.Vibrate();
        #endif
        var i = Random.Range(0, 2);
        audioSource.Stop();
        audioSource.PlayOneShot(impactAudios[i]);
    }

}
