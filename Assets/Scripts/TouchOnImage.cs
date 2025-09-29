using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchOnImage : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPressed = false;
    [SerializeField] private bool left;
    [SerializeField] private bool middle;
    [SerializeField] private bool play;
    [SerializeField] private bool retry;
    [SerializeField] private bool exit;
    //[SerializeField] private Image btnLeft;
    [SerializeField] private Controls controls;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        //btnLeft.color = Color.black;
        if (left)
        {
            controls.Left();
        }
        else if (middle)
        {
            controls.Middle();
            Debug.Log("middle pressed");
        }
        else if (play)
        {
            controls.Play();
        }
        else if (exit)
        {
            controls.Exit();
        }
        else if (retry)
        {
            controls.Retry();
        }
        else
        {
            controls.Right();
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        //btnLeft.color = Color.white;
        controls.Center();
    }
}
