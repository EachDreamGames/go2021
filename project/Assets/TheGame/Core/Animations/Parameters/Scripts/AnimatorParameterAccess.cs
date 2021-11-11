using UnityEngine;

namespace TheGame.Core.Animations.Parameters
{
  public abstract class AnimatorParameterAccess<TAnimatorParameter> : MonoBehaviour where TAnimatorParameter : AnimatorParameter
  {
    [SerializeField] private Animator _animator;
    [SerializeField] private TAnimatorParameter _parameter;

    protected Animator Animator => _animator;
    protected TAnimatorParameter Parameter => _parameter;
  }
}