
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInputController : MonoBehaviour
{
    [Header("Referencias a los personajes")]
    public PlayerController topPlayer;
    public PlayerController bottomPlayer;

    void Update()
    {
        // Detectar toques en móvil mediante el nuevo Input System.
        if (Touchscreen.current != null)
        {
            foreach (var touch in Touchscreen.current.touches)
            {
                if (touch.press.wasPressedThisFrame)
                {
                    Vector2 position = touch.position.ReadValue();
                    ProcessTap(position);
                }
            }
        }

        // Permitir pruebas con clic del ratón en el editor.
#if UNITY_EDITOR
        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            ProcessTap(Mouse.current.position.ReadValue());
        }
#endif
    }

    void ProcessTap(Vector2 position)
    {
        if (position.y >= Screen.height / 2f)
        {
            if (topPlayer != null)
                topPlayer.Jump();
        }
        else
        {
            if (bottomPlayer != null)
                bottomPlayer.Jump();
        }
    }
}
