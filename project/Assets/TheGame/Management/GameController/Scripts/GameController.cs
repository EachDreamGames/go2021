using System;
using TheGame.Core.Animations.Parameters;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TheGame.Management.GameController
{
  public class GameController : MonoBehaviour, InputControls.IGameControllerActions
  {
    [SerializeField] private Animator _animator;
    [SerializeField] private TriggerAnimatorParameter _inputAnyKeyParameter;
    [SerializeField] private TriggerAnimatorParameter _inputCloseParameter;
    [SerializeField] private TriggerAnimatorParameter _shouldStartNewGameParameter;
    [SerializeField] private TriggerAnimatorParameter _shouldContinueGameParameter;
    [SerializeField] private TriggerAnimatorParameter _shouldShowSettingsParameter;
    [SerializeField] private TriggerAnimatorParameter _shouldShowHelpParameter;
    [SerializeField] private TriggerAnimatorParameter _shouldShowCreditsParameter;
    [SerializeField] private TriggerAnimatorParameter _shouldExitGameParameter;

    private InputControls _inputControls;

    private void Awake()
    {
      _inputControls = new InputControls();
      _inputControls.GameController.SetCallbacks(this);
    }

    private void OnEnable() =>
      _inputControls.Enable();

    private void OnDisable() =>
      _inputControls.Disable();

    public void StartNewGame() =>
      _animator.SetTrigger(_shouldStartNewGameParameter);

    public void ContinueGame() =>
      _animator.SetTrigger(_shouldContinueGameParameter);

    public void ShowSettings() =>
      _animator.SetTrigger(_shouldShowSettingsParameter);

    public void ShowHelp() =>
      _animator.SetTrigger(_shouldShowHelpParameter);

    public void ShowCredits() =>
      _animator.SetTrigger(_shouldShowCreditsParameter);

    public void ExitGame() =>
      _animator.SetTrigger(_shouldExitGameParameter);

    public void OnAnyKey(InputAction.CallbackContext context)
    {
      switch (context.phase)
      {
        case InputActionPhase.Started:
          _animator.SetTrigger(_inputAnyKeyParameter);
          break;
        case InputActionPhase.Canceled:
        case InputActionPhase.Disabled:
        case InputActionPhase.Waiting:
          _animator.ResetTrigger(_inputAnyKeyParameter);
          break;
        case InputActionPhase.Performed:
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    public void OnClose(InputAction.CallbackContext context)
    {
      switch (context.phase)
      {
        case InputActionPhase.Started:
          _animator.SetTrigger(_inputCloseParameter);
          break;
        case InputActionPhase.Canceled:
        case InputActionPhase.Disabled:
        case InputActionPhase.Waiting:
          _animator.ResetTrigger(_inputCloseParameter);
          break;
        case InputActionPhase.Performed:
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }
  }
}