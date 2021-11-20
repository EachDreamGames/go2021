using Sirenix.OdinInspector;
using UnityEngine;

namespace TheGame.Core.Animations.Attributes
{
  public abstract class AnimatorStateAttributeBehaviour : MonoBehaviour
  {
    [SerializeField, CustomContextMenu("Set from self or parent", nameof(SetAnimatorFromSelfOrParent))]
    private Animator _animator;

    [SerializeField] private AnimatorStateAttribute _stateAttribute;

    private AnimatorExtensions.Attributes _attributes;
    private bool _isStateActive;

    protected Animator Animator => _animator;

    protected bool IsStateActive
    {
      get => _isStateActive;
      private set
      {
        if (value == _isStateActive) return;

        _isStateActive = value;
        if (_isStateActive)
          OnStateActivate();
        else
          OnStateDeactivate();
      }
    }

    private void Awake() =>
      _attributes = _animator.GetAttributes();

    protected virtual void OnEnable()
    {
      IsStateActive = _attributes.IsActive(_stateAttribute);
      _attributes.OnChanged += AttributesChanged;
    }

    protected virtual void OnDisable()
    {
      IsStateActive = false;
      _attributes.OnChanged -= AttributesChanged;
    }

    protected virtual void FixedUpdate()
    {
      if (IsStateActive)
        OnStateUpdate();
    }

    protected virtual void OnStateActivate()
    {
    }

    protected virtual void OnStateDeactivate()
    {
    }

    protected virtual void OnStateUpdate()
    {
    }

    private void AttributesChanged(AnimatorStateAttribute attribute, bool isActive)
    {
      if (attribute == _stateAttribute)
        IsStateActive = isActive;
    }

    private void SetAnimatorFromSelfOrParent() =>
      _animator = GetComponentInParent<Animator>();
  }
}