using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour
{
    public List<TutorialStep> steps = new();
    private int current = 0;
    private bool audioFinished = false;
    private bool userDidAction = false;

    void Start()
    {
        StartCoroutine(TutorialFlow());
    }

    private IEnumerator TutorialFlow()
    {
        while (current < steps.Count)
        {
            audioFinished = false;
            userDidAction = false;

            var step = steps[current];

            SoundManager.PlayTutorialClip(step.clip, () =>
            {
                audioFinished = true;
            });

            yield return new WaitUntil(() => audioFinished);

            if (step.expectedAction != TutorialAction.None)
            {
                yield return new WaitUntil(() => userDidAction);
            }

            current++;
        }

        Debug.Log("Tutorial concluído!");
        OnTutorialComplete();
    }

    public void ConfirmAction(TutorialAction action)
    {
        var step = steps[current];

        if (step.expectedAction == action)
            userDidAction = true;
    }

    private void OnTutorialComplete()
{
    Debug.Log("Tutorial concluído!");
    FindObjectOfType<Menu>().NextScene();
}

}
