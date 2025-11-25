using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadInfiniteMode : MonoBehaviour
{
[Tooltip("Tempo em segundos antes de trocar de cena")]
    public float delay = 130f;

    void Start()
    {
        StartCoroutine(LoadNext());
    }

    private System.Collections.IEnumerator LoadNext()
    {
        yield return new WaitForSeconds(delay);

        int indexAtual = SceneManager.GetActiveScene().buildIndex;
        int proximaCena = indexAtual + 1;

        if (proximaCena < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(proximaCena);
        }
        else
        {
            Debug.LogWarning("Não existe próxima cena configurada na Build Settings!");
        }
    }
}