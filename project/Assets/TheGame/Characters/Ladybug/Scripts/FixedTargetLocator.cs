using UnityEngine;

namespace TheGame.Characters.Ladybug
{
  public class FixedTargetLocator : TargetLocator
  {
    [SerializeField] private Transform _target;

    public override GameObject Target => _target.gameObject;
  }
}