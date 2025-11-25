using UnityEngine;

public class SoundMenu : MonoBehaviour
{
    void Start()
    {
        SoundManager.PlaySound(SoundType.DIALOGUE_MENU);
        //Debug.Log("teste");

    }

}
