using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TheGame.Common
{
  [CreateAssetMenu(fileName = "NewMouseHelper", menuName = "Utils/MouseHelper")]
  public class MouseHelper : ScriptableObject
  {
    [ReadOnly] public Camera Camera;

    public Vector3 GetCursorPosition()
    {
      if (!Camera)
      {
        Debug.LogError("Camera not defined");
        return Vector3.zero;
      }

      Vector3 cursorPosition = Camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
      cursorPosition.z = 0;
      return cursorPosition;
    }
  }
}