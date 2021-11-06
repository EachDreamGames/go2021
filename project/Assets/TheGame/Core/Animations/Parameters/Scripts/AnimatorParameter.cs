using UnityEngine;

namespace TheGame.Core.Animations.Parameters
{
  public abstract class AnimatorParameter : ScriptableObject
  {
    [SerializeField] private string _name;

    protected internal int ParamHash { get; private set; }

    private void OnEnable() =>
      ParamHash = Animator.StringToHash(_name);
  }
}