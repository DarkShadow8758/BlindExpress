using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int life = 3;
    [SerializeField] private TextMeshProUGUI tmpLife;
    void Start()
    {
        tmpLife.text = life.ToString();
    }
    public void Damage()
    {
        life--;
        tmpLife.text = life.ToString();
        Handheld.Vibrate();
        if (life <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
