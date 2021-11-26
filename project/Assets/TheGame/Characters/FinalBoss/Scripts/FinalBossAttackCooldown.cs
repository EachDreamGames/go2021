using System.Collections;
using Sirenix.OdinInspector;
using TheGame.Core.Animations.Attributes;
using TheGame.Core.Animations.Parameters;
using UnityEngine;

namespace TheGame.Characters.FinalBoss.Scripts
{
  public class FinalBossAttackCooldown : AnimatorStateAttributeBehaviour
  {
    [SerializeField] private BoolAnimatorParameter _isAttackCoolingParameter;
    [SerializeField, SuffixLabel("s")] private float _timer;

    protected override void OnStateActivate() =>
      StartCooling();

    protected override void OnStateDeactivate()
    {
      if (!isActiveAndEnabled) return;
      StartCoroutine(StopCooling());
    }

    private void StartCooling() =>
      Animator.SetValue(_isAttackCoolingParameter, true);

    private IEnumerator StopCooling()
    {
      yield return new WaitForSeconds(_timer);
      Animator.SetValue(_isAttackCoolingParameter, false);
    }
  }
}