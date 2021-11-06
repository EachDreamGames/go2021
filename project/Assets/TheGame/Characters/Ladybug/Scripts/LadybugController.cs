using System;
using TheGame.Core.Animations.Parameters;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TheGame.Characters.Ladybug
{
  public class LadybugController : MonoBehaviour, InputControls.ILadybugActions
  {
    [SerializeField] private Animator _animator;
    [SerializeField] private IntAnimatorParameter _movementDirectionParameter;
    [SerializeField] private FloatAnimatorParameter _movementSpeedParameter;
    [SerializeField] private float _movementSpeed;

    private InputControls _inputControls;

    private void Awake()
    {
      _inputControls = new InputControls();
      _inputControls.Ladybug.SetCallbacks(this);
    }

    private void OnEnable() =>
      _inputControls.Enable();

    private void OnDisable() =>
      _inputControls.Disable();

    private void Start() =>
      _animator.SetValue(_movementSpeedParameter, _movementSpeed);

    public void OnWalk(InputAction.CallbackContext context)
    {
      switch (context.phase)
      {
        case InputActionPhase.Started:
        case InputActionPhase.Performed:
          _animator.SetValue(_movementDirectionParameter, (int)context.ReadValue<float>());
          break;
        case InputActionPhase.Disabled:
        case InputActionPhase.Waiting:
        case InputActionPhase.Canceled:
          _animator.SetValue(_movementDirectionParameter, 0);
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }
  }
}