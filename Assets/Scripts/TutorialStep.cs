using UnityEngine;

public enum TutorialAction
{
    None,
    Right,
    Left
}

[System.Serializable]
public class TutorialStep
{
    public AudioClip clip;
    public TutorialAction expectedAction;
}
