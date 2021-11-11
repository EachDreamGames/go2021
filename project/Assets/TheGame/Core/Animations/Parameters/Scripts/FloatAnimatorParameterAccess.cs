namespace TheGame.Core.Animations.Parameters
{
  public class FloatAnimatorParameterAccess : AnimatorParameterAccess<FloatAnimatorParameter>
  {
    public float Value
    {
      get => Animator.GetValue(Parameter);
      set => Animator.SetValue(Parameter, value);
    }
  }
}