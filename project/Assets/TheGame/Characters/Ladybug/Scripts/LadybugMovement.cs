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

    protected override void OnStateDeactivate() =>
      _body.velocity = new Vector2(0, _body.velocity.y);

    protected override void OnStateUpdate() =>
      _body.velocity = new Vector2(Animator.GetValue(_speed) * Animator.GetValue(_direction), _body.velocity.y);
  }
}