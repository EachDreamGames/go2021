using UnityEngine;

namespace TheGame.Core.Animations.Layers
{
  public class AnimatorLayerAccess : MonoBehaviour
  {
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimatorLayer _layer;

    public float Weight
    {
      get => _animator.GetLayerWeight(_layer);
      set => _animator.SetLayerWeight(_layer, value);
    }
  }
}