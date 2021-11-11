using UnityEngine;

namespace TheGame.Core.Animations.Parameters
{
  public class ResetTriggerParameters : StateMachineBehaviour
  {
    [SerializeField] private TriggerAnimatorParameter[] _triggers;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      foreach (TriggerAnimatorParameter triggerParameter in _triggers) 
        animator.ResetTrigger(triggerParameter);
    }
  }
}