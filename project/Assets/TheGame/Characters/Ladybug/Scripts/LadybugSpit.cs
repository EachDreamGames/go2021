using Sirenix.OdinInspector;
using TheGame.Common;
using TheGame.Core.Animations.Attributes;
using TheGame.Core.Animations.Parameters;
using TheGame.Core.Common;
using TheGame.Core.Common.Utils;
using UnityEngine;

namespace TheGame.Characters.Ladybug
{
  public class LadybugSpit : AnimatorStateAttributeBehaviour
  {
    [SerializeField] private BoolAnimatorParameter _isSpitPreparedParameter;
    [SerializeField] private MouseHelper _mouseHelper;
    [SerializeField] private LadybugSpitLaunchAnimationsEvents _launchAnimationsEvents;
    [SerializeField, AssetSelector] private ProjectileEngine _projectilePrefab;
    [SerializeField] private Transform _point;
    [SerializeField] private TargetLocator _targetLocator;

    private ProjectileEngine _preparedProjectile;

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
      _preparedProjectile.GetOrAddSibling<DestroyEvent>().OnDestroyEvent += PreparedProjectileDestroyed;
      Animator.SetValue(_isSpitPreparedParameter, true);
    }

    private void DoSpitLaunch()
    {
      if (!_preparedProjectile)
      {
        PreparedProjectileDestroyed();
        return;
      }

      _preparedProjectile.GetOrAddSibling<DestroyEvent>().OnDestroyEvent -= PreparedProjectileDestroyed;

      _preparedProjectile.transform.parent = null;
      if (_targetLocator.Target == null)
        _preparedProjectile.Launch(_mouseHelper.GetCursorPosition());
      else
        _preparedProjectile.Launch(_targetLocator.Target);
      Animator.SetValue(_isSpitPreparedParameter, false);
    }

    private void PreparedProjectileDestroyed()
    {
      _preparedProjectile = null;
      Animator.SetValue(_isSpitPreparedParameter, false);
    }
  }
}