using UnityEngine;

public class SoundEnd : MonoBehaviour
{
    void Start()
    {
        SoundManager.PlaySound(SoundType.DIALOGUE_END);
    }
}
