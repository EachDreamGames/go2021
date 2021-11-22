using System;
using Sirenix.OdinInspector;
using TheGame.Core.Animations.Parameters;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TheGame.Characters.Ladybug
{
  public class LadybugController : MonoBehaviour, InputControls.ILadybugActions
  {
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimatorParameters _parameters;
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
          _animator.SetTrigger(_parameters.ShouldJump);
          break;
        case InputActionPhase.Performed:
          break;
        case InputActionPhase.Disabled:
        case InputActionPhase.Waiting:
        case InputActionPhase.Canceled:
          _animator.ResetTrigger(_parameters.ShouldJump);
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
      _animator.SetValue(_parameters.MovementSpeed, _movementSpeed);
      _animator.SetValue(_parameters.MovementDirection, _movementDirection);
    }

    public void OnInteract(InputAction.CallbackContext context) =>
      _animator.SetTrigger(_parameters.ShouldInteract);

    public void OnKick(InputAction.CallbackContext context)
    {
      if (!context.started) return;
      _animator.SetTrigger(_parameters.ShouldKick);
    }

    public void OnSpit(InputAction.CallbackContext context)
    {
      if (!context.started && !context.canceled) return;
      _animator.SetTrigger(_parameters.ShouldSpit);
    }

    public void OnAim(InputAction.CallbackContext context)
    {
    }

    public void OnMouseAim(InputAction.CallbackContext context)
    {
    }

    [Serializable, HideLabel, FoldoutGroup("Animator Parameters", true)]
    [ValidateInput(nameof(ValidateParameters), "All parameters should be assigned.")]
    private struct AnimatorParameters
    {
      public IntAnimatorParameter MovementDirection;
      public FloatAnimatorParameter MovementSpeed;
      public TriggerAnimatorParameter ShouldJump;
      public TriggerAnimatorParameter ShouldInteract;
      public TriggerAnimatorParameter ShouldSpit;
      public TriggerAnimatorParameter ShouldKick;
    }

    private bool ValidateParameters() =>
      _parameters.MovementDirection != null &&
      _parameters.MovementSpeed != null &&
      _parameters.ShouldJump != null &&
      _parameters.ShouldInteract != null &&
      _parameters.ShouldSpit != null &&
      _parameters.ShouldKick != null;
  }
}