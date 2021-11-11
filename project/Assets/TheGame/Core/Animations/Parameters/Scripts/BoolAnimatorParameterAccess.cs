namespace TheGame.Core.Animations.Parameters
{
  public class BoolAnimatorParameterAccess : AnimatorParameterAccess<BoolAnimatorParameter>
  {
    public bool Value
    {
      get => Animator.GetValue(Parameter);
      set => Animator.SetValue(Parameter, value);
    }
  }
}