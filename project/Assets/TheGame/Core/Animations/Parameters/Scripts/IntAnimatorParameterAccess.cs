namespace TheGame.Core.Animations.Parameters
{
  public class IntAnimatorParameterAccess : AnimatorParameterAccess<IntAnimatorParameter>
  {
    public int Value
    {
      get => Animator.GetValue(Parameter);
      set => Animator.SetValue(Parameter, value);
    }
  }
}