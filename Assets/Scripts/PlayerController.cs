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
         Debug.Log("dano");
    // Vibrate only on mobile platforms (Handheld exists there)
    #if UNITY_ANDROID || UNITY_IOS
        Handheld.Vibrate();
    #endif
        var i = Random.Range(0, 2);
        audioSource.Stop();
        audioSource.PlayOneShot(impactAudios[i]);
        if (life <= 0)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(2);
        }
    }
    public void GainLife()
    {
        life += 1;
        tmpLife.text = life.ToString();
        Debug.Log("vida");
        // Vibrate only on mobile platforms (Handheld exists there)
        #if UNITY_ANDROID || UNITY_IOS
                Handheld.Vibrate();
        #endif
        var i = Random.Range(0, 2);
        audioSource.Stop();
        audioSource.PlayOneShot(impactAudios[i]);
    }

}
