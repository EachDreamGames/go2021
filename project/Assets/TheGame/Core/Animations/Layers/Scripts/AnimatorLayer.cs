using UnityEngine;

namespace TheGame.Core.Animations.Layers
{
  [CreateAssetMenu(fileName = "NewAnimatorLayer", menuName = "Animator/Layer")]
  public class AnimatorLayer : ScriptableObject
  {
    [SerializeField] private int _index;

    public int Index => _index;
  }
}