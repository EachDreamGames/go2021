using Sirenix.OdinInspector;
using UnityEngine;

namespace TheGame.Common
{
  public class StaticTargetLocator : TargetLocator
  {
    [SerializeField, AssetSelector] private StaticTargetContainer _container;

    public override GameObject Target => _container.Target;
  }
}