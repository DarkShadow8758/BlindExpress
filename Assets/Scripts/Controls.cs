using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    [SerializeField] private Image btnLeft;
    [SerializeField] private Image btnRight;
    public int playerLocation = 1;


    //public void OnLeft(InputValue value)
    public void OnLeft(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            btnLeft.color = Color.blue;
            playerLocation = 0;
        }
        else
        {
            btnLeft.color = Color.white;
            playerLocation = 1;
        }

    }
    public void OnRight(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            btnRight.color = Color.red;
            playerLocation = 2;
        }
        else
        {
            btnRight.color = Color.white;
            playerLocation = 1;
        }
    }

    public void Left()
    {
        playerLocation = 0;
    }
    public void Right()
    {
        playerLocation = 2;
    }
    public void Center()
    {
        playerLocation = 1;
    }
    
}
