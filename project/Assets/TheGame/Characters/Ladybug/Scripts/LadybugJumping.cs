using System;
using Sirenix.OdinInspector;
using TheGame.Core.Animations.Attributes;
using UnityEngine;

namespace TheGame.Characters.Ladybug
{
  public class LadybugJumping : AnimatorStateAttributeBehaviour
  {
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private float _height;
    [SerializeField] private bool _compensateFallingSpeed;
    [SerializeField] private ImpulseMethod _impulseMethod;

    protected override void OnStateActivate()
    {
      if (_impulseMethod == ImpulseMethod.OnStateActivate)
        ApplyImpulse();
    }

    protected override void OnStateDeactivate()
    {
      if (_impulseMethod == ImpulseMethod.OnStateDeactivate)
        ApplyImpulse();
    }

    private void ApplyImpulse()
    {
      if (_compensateFallingSpeed && _body.velocity.y < 0)
        _body.velocity = new Vector2(_body.velocity.x, 0);

      float gravityCompensationImpulse = -CalculateGravityForce() * Time.fixedDeltaTime;
      float jumpImpulse = gravityCompensationImpulse + 2 * _height / CalculateFreeFallTime() * _body.mass;
      _body.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
    }

    private float CalculateGravityForce() =>
      Physics2D.gravity.y * _body.gravityScale * _body.mass;

    private float CalculateFreeFallTime()
    {
      float acceleration = Physics2D.gravity.y * _body.gravityScale;
      return Mathf.Sqrt(-_height * 2 / acceleration);
    }

    [Serializable, EnumToggleButtons]
    private enum ImpulseMethod
    {
      OnStateActivate,
      OnStateDeactivate
    }
  }
}