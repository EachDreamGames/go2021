using Sirenix.OdinInspector;
using TheGame.Common;
using TheGame.Core.Animations.Attributes;
using TheGame.Core.Animations.Parameters;
using UnityEngine;

namespace TheGame.Characters.Ladybug
{
  public class LadybugSpit : AnimatorStateAttributeBehaviour
  {
    [SerializeField] private BoolAnimatorParameter _isSpitPreparedParameter;
    [SerializeField] private Rigidbody2D _ladybugBody;
    [SerializeField] private LadybugSpitLaunchAnimationsEvents _launchAnimationsEvents;
    [SerializeField, AssetSelector] private Projectile _projectilePrefab;
    [SerializeField] private float _spitImpulse;
    [SerializeField] private Transform _point;
    [SerializeField] private Transform _target;

    private Projectile _preparedProjectile;

    private void Start() =>
      _launchAnimationsEvents.OnSpitLaunch += DoSpitLaunch;

    private void OnDestroy() =>
      _launchAnimationsEvents.OnSpitLaunch -= DoSpitLaunch;

    protected override void OnStateActivate()
    {
      if (Animator.GetValue(_isSpitPreparedParameter)) return;

      PrepareProjectile();
    }

    private void PrepareProjectile()
    {
      _preparedProjectile = Instantiate(_projectilePrefab, _point.position, Quaternion.identity);
      _preparedProjectile.transform.parent = _point;
      Animator.SetValue(_isSpitPreparedParameter, true);
    }

    private void DoSpitLaunch()
    {
      _preparedProjectile.transform.parent = null;
      _preparedProjectile.Launch(_ladybugBody.velocity, (_target.position - _point.position).normalized * _spitImpulse);
      Animator.SetValue(_isSpitPreparedParameter, false);
    }
  }
}