using TheGame.Core.Animations.Attributes;
using TheGame.Core.Animations.Parameters;
using UnityEngine;

namespace TheGame.Characters.Ladybug
{
  public class LadybugAirJumpCounter : AnimatorStateAttributeBehaviour
  {
    [SerializeField] private IntAnimatorParameter _availableCountParameter;
    [SerializeField] private BoolAnimatorParameter _isGroundedParameter;
    [SerializeField] private int _maxCount;

    private void Start() =>
      ResetCount();

    protected override void FixedUpdate()
    {
      if (Animator.GetValue(_isGroundedParameter))
        ResetCount();
    }

    protected override void OnStateActivate() =>
      Animator.SetValue(_availableCountParameter, Animator.GetValue(_availableCountParameter) - 1);

    public void ResetCount() =>
      Animator.SetValue(_availableCountParameter, _maxCount);
  }
}