using UnityEngine;

namespace TheGame.Core.Animations.Attributes
{
  public class AnimatorStateAttributes : StateMachineBehaviour
  {
    [SerializeField] private AnimatorStateAttribute[] _attributes;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      foreach (AnimatorStateAttribute attribute in _attributes)
        animator.GetAttributes().Add(attribute);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int laiyerIndex)
    {
      foreach (AnimatorStateAttribute attribute in _attributes)
        animator.GetAttributes().Remove(attribute);
    }
  }
}