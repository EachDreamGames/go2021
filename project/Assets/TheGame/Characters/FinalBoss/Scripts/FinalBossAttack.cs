using Sirenix.OdinInspector;
using TheGame.Common;
using TheGame.Core.Animations.Attributes;
using UnityEngine;

namespace TheGame.Characters.FinalBoss.Scripts
{
  public class FinalBossAttack : AnimatorStateAttributeBehaviour
  {
    [SerializeField] private TargetLocator _targetLocator;
    [SerializeField] private Transform _point;
    [SerializeField, AssetSelector] private ProjectileEngine _projectilePrefab;

    protected override void OnStateActivate() =>
      LaunchProjectile();

    private void LaunchProjectile()
    {
      ProjectileEngine projectile = Instantiate(_projectilePrefab, _point.position, Quaternion.identity);
      projectile.Launch(_targetLocator.Target);
    }
  }
}