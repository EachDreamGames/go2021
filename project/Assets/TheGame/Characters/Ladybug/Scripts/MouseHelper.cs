using UnityEngine;
using UnityEngine.InputSystem;

namespace TheGame.Characters.Ladybug
{
  public class MouseHelper : MonoBehaviour
  {
    [SerializeField] private Camera _camera;

    public Vector3 GetCursorPosition()
    {
      Vector3 cursorPosition = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
      cursorPosition.z = 0;
      return cursorPosition;
    }
  }
}