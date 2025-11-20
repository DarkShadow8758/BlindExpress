using UnityEngine;

public class MancheController : MonoBehaviour
{
    public Animator anim;
    private float direcao = 0f;

    void Update()
    {
        anim.SetFloat("Direcao", direcao);
    }

    public void PressRight() { direcao = 1f; }
    public void PressLeft() { direcao = -1f; }
    public void Release() { direcao = 0f; }
}
