using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchOnImage : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPressed = false;
    [SerializeField] private bool left;
    [SerializeField] private Image btnLeft;
    [SerializeField] private Controls controls;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        Debug.Log("Imagem tocada!");
        btnLeft.color = Color.black;
        if (left)
        {
            controls.Left();
        }
        else
        {
            controls.Right();
        }
        

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        Debug.Log("Imagem liberada!");
        btnLeft.color = Color.white;
        controls.Center();
    }
}
