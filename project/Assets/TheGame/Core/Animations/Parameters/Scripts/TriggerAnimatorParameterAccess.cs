namespace TheGame.Core.Animations.Parameters
{
  public class TriggerAnimatorParameterAccess : AnimatorParameterAccess<TriggerAnimatorParameter>
  {
    public bool Value
    {
      set => Animator.SetValue(Parameter, value);
    }

    public void SetTrigger() =>
      Animator.SetTrigger(Parameter);

    public void ResetTrigger() =>
      Animator.ResetTrigger(Parameter);
  }
}