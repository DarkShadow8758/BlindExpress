using UnityEngine;

public class ButtonTutorial : MonoBehaviour
{
    public void ClickRight()
    {
        FindObjectOfType<TutorialManager>().ConfirmAction(TutorialAction.Right);
    }
    

}
