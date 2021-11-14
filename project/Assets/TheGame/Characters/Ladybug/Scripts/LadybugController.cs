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
    [SerializeField] private TriggerAnimatorParameter _shouldJumpParameter;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;

    private InputControls _inputControls;
    private float _movementSpeed;
    private int _movementDirection;

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
      _movementSpeed = _walkSpeed;

    public void OnWalk(InputAction.CallbackContext context)
    {
      switch (context.phase)
      {
        case InputActionPhase.Started:
        case InputActionPhase.Performed:
          _movementDirection = Math.Max(-1, Math.Min(1, (int)context.ReadValue<float>()));
          break;
        case InputActionPhase.Disabled:
        case InputActionPhase.Waiting:
        case InputActionPhase.Canceled:
          _movementDirection = 0;
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }

      ApplyMovementParams();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
      switch (context.phase)
      {
        case InputActionPhase.Started:
          _animator.SetTrigger(_shouldJumpParameter);
          break;
        case InputActionPhase.Performed:
          break;
        case InputActionPhase.Disabled:
        case InputActionPhase.Waiting:
        case InputActionPhase.Canceled:
          _animator.ResetTrigger(_shouldJumpParameter);
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    public void OnIsRunning(InputAction.CallbackContext context)
    {
      switch (context.phase)
      {
        case InputActionPhase.Started:
          _movementSpeed = _runSpeed;
          break;
        case InputActionPhase.Performed:
          break;
        case InputActionPhase.Disabled:
        case InputActionPhase.Waiting:
        case InputActionPhase.Canceled:
          _movementSpeed = _walkSpeed;
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }

      ApplyMovementParams();
    }

    public void OnWalkSpeedMultiplier(InputAction.CallbackContext context)
    {
      switch (context.phase)
      {
        case InputActionPhase.Started:
        case InputActionPhase.Performed:
          _movementSpeed = _runSpeed * Mathf.Abs(context.ReadValue<float>());
          Debug.Log(_movementSpeed);
          break;
        case InputActionPhase.Disabled:
          break;
        case InputActionPhase.Waiting:
          break;
        case InputActionPhase.Canceled:
          _movementSpeed = _walkSpeed;
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }

      ApplyMovementParams();
    }

    private void ApplyMovementParams()
    {
      _animator.SetValue(_movementSpeedParameter, _movementSpeed);
      _animator.SetValue(_movementDirectionParameter, _movementDirection);
    }
  }
}