using TheGame.Core.Animations.Attributes;
using TheGame.Core.Animations.Parameters;
using UnityEngine;

namespace TheGame.Characters.Ladybug
{
  public class LadybugMovement : AnimatorStateAttributeBehaviour
  {
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private IntAnimatorParameter _directionParameter;
    [SerializeField] private FloatAnimatorParameter _speedParameter;
    [SerializeField] private BoolAnimatorParameter _isWallTouchingParameter;

    protected override void OnStateDeactivate() =>
      _body.velocity = new Vector2(0, _body.velocity.y);

    protected override void OnStateUpdate()
    {
      if (Animator.GetValue(_isWallTouchingParameter)) return;

      _body.velocity = new Vector2(Animator.GetValue(_speedParameter) * Animator.GetValue(_directionParameter), _body.velocity.y);
    }
  }
}