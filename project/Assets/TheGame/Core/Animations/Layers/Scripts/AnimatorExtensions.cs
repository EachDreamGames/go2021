using UnityEngine;

namespace TheGame.Core.Animations.Layers
{
  public static class AnimatorExtensions
  {
    public static void SetLayerWeight(this Animator animator, AnimatorLayer layer, float value) =>
      animator.SetLayerWeight(layer.Index, value);

    public static float GetLayerWeight(this Animator animator, AnimatorLayer layer) =>
      animator.GetLayerWeight(layer.Index);
  }
}