using UnityEngine;

namespace TheGame.Core.Animations.Attributes
{
  public abstract class AnimatorStateAttributeBehaviour : MonoBehaviour
  {
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimatorStateAttribute _stateAttribute;

    private AnimatorExtensions.Attributes _attributes;
    private bool _isActive;

    protected Animator Animator => _animator;

    public bool IsActive
    {
      get => _isActive;
      private set
      {
        if (value == _isActive) return;

        _isActive = value;
        if (_isActive)
          OnActivate();
        else
          OnDeactivate();
      }
    }

    private void Awake() =>
      _attributes = _animator.GetAttributes();

    protected virtual void OnEnable()
    {
      IsActive = _attributes.IsActive(_stateAttribute);
      _attributes.OnChanged += AttributesChanged;
    }

    protected virtual void OnDisable()
    {
      IsActive = false;
      _attributes.OnChanged -= AttributesChanged;
    }

    protected virtual void FixedUpdate()
    {
      if (IsActive)
        OnStateUpdate();
    }

    protected virtual void OnActivate()
    {
    }

    protected virtual void OnDeactivate()
    {
    }

    protected virtual void OnStateUpdate()
    {
    }

    private void AttributesChanged(AnimatorStateAttribute attribute, bool isActive)
    {
      if (attribute == _stateAttribute)
        IsActive = isActive;
    }
  }
}