using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TheGame.GameScreens
{
  public class GameScreen : MonoBehaviour, InputControls.IMenuActions
  {
    private InputControls _inputControls;

    public event Action OnAnyKey;
    public event Action OnClose;

    private void Awake()
    {
      _inputControls = new InputControls();
      _inputControls.Menu.SetCallbacks(this);
    }

    private void OnEnable() =>
      _inputControls.Enable();

    private void OnDisable() =>
      _inputControls.Disable();

    void InputControls.IMenuActions.OnAnyKey(InputAction.CallbackContext context)
    {
      OnAnyKey?.Invoke();
    }

    void InputControls.IMenuActions.OnClose(InputAction.CallbackContext context)
    {
      OnClose?.Invoke();
    }
  }
}