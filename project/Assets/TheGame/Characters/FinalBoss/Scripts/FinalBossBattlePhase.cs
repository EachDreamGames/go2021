using Sirenix.OdinInspector;
using TheGame.Core.Animations.Attributes;
using TheGame.Core.Animations.Layers;
using TheGame.Core.Animations.Parameters;
using UnityEngine;

namespace TheGame.Characters.FinalBoss.Scripts
{
  public class FinalBossBattlePhase : AnimatorStateAttributeBehaviour
  {
    [SerializeField, AssetSelector] private AnimatorLayer _battleLayer;
    [SerializeField] private IntAnimatorParameter _isBattlePhaseNumberParameter;

    protected override void OnStateActivate()
    {
      Animator.SetLayerWeight(_battleLayer, 1);
      Animator.SetValue(_isBattlePhaseNumberParameter, _battleLayer.Index);
    }

    protected override void OnStateDeactivate()
    {
      Animator.SetLayerWeight(_battleLayer, 0);
      Animator.SetValue(_isBattlePhaseNumberParameter, _battleLayer.Index);
    }
  }
}