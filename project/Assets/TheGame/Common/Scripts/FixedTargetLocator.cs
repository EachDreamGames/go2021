using UnityEngine;

namespace TheGame.Common
{
  public class FixedTargetLocator : TargetLocator
  {
    [SerializeField] private Transform _target;

    public override GameObject Target => _target.gameObject;
  }
}