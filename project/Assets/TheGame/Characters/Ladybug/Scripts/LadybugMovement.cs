using TheGame.Core.Animations.Attributes;
using TheGame.Core.Animations.Parameters;
using UnityEngine;

namespace TheGame.Characters.Ladybug
{
  public class LadybugMovement : AnimatorStateAttributeBehaviour
  {
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private IntAnimatorParameter _direction;
    [SerializeField] private FloatAnimatorParameter _speed;

    protected override void OnDeactivate() =>
      _body.velocity = Vector2.zero;

    protected override void OnStateUpdate() =>
      _body.velocity = new Vector2(Animator.GetValue(_speed) * Animator.GetValue(_direction), _body.velocity.y);
  }
}