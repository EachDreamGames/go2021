using TheGame.Core.Animations.Attributes;
using TheGame.Core.Animations.Parameters;
using UnityEngine;

namespace TheGame.Characters.Ladybug
{
  public class LadybugOrientation : AnimatorStateAttributeBehaviour
  {
    [SerializeField] private Transform _rootTransform;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private IntAnimatorParameter _orientationParameter;

    private int _prevOrientation;

    protected override void OnStateActivate() =>
      UpdateOrientation();

    protected override void OnStateUpdate() =>
      UpdateOrientation();

    private void UpdateOrientation()
    {
      int orientation = Animator.GetValue(_orientationParameter);
      if (_prevOrientation == orientation) return;

      Vector3 localScale = _rootTransform.localScale;
      localScale.x = orientation < 0 ? -1 : orientation > 0 ? 1 : localScale.x;
      _rootTransform.localScale = localScale;
      _renderer.flipX = localScale.x < 0;

      _prevOrientation = orientation;
    }
  }
}