using UnityEngine;
using UnityEngine.Events;

namespace TheGame.Core.Animations.Attributes
{
  public sealed class AnimatorStateAttributeEvents : AnimatorStateAttributeBehaviour
  {
    [SerializeField] private UnityEvent _onActivate;
    [SerializeField] private UnityEvent _onDeactivate;

    protected override void OnActivate() =>
      _onActivate?.Invoke();

    protected override void OnDeactivate() =>
      _onDeactivate?.Invoke();
  }
}