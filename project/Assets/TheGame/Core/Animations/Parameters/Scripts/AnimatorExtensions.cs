using UnityEngine;

namespace TheGame.Core.Animations.Parameters
{
  public static class AnimatorExtensions
  {
    public static void SetValue(this Animator animator, IntAnimatorParameter parameter, int value) =>
      animator.SetInteger(parameter.ParamHash, value);

    public static int GetValue(this Animator animator, IntAnimatorParameter parameter) =>
      animator.GetInteger(parameter.ParamHash);

    public static void SetValue(this Animator animator, FloatAnimatorParameter parameter, float value) =>
      animator.SetFloat(parameter.ParamHash, value);

    public static float GetValue(this Animator animator, FloatAnimatorParameter parameter) =>
      animator.GetFloat(parameter.ParamHash);

    public static void SetValue(this Animator animator, BoolAnimatorParameter parameter, bool value) =>
      animator.SetBool(parameter.ParamHash, value);

    public static bool GetValue(this Animator animator, BoolAnimatorParameter parameter) =>
      animator.GetBool(parameter.ParamHash);

    public static void SetValue(this Animator animator, TriggerAnimatorParameter parameter, bool value)
    {
      if (value)
        animator.SetTrigger(parameter.ParamHash);
      else
        animator.ResetTrigger(parameter.ParamHash);
    }

    public static void SetTrigger(this Animator animator, TriggerAnimatorParameter parameter) =>
      animator.SetTrigger(parameter.ParamHash);

    public static void ResetTrigger(this Animator animator, TriggerAnimatorParameter parameter) =>
      animator.ResetTrigger(parameter.ParamHash);
  }
}