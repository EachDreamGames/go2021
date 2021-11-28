using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TheGame.Common
{
  public class ProjectileCore : MonoBehaviour
  {
    [SerializeField, SuffixLabel("s"), MinValue(0)]
    private float _lifeTime;

    [SerializeField, EnableIf(nameof(IsLifeTimeDefined))]
    private bool _detonateAfterLifeTimeExpired;

    [SerializeField] private Transform _point;
    [SerializeField] private LayerMask _targetLayers;
    [SerializeField] private GameObject _hitFx;
    [SerializeField] private float _radius;

    private readonly Collider2D[] _overlappedColliders = new Collider2D[10];
    private readonly List<ProjectileTarget> _targets = new List<ProjectileTarget>();
    private bool IsLifeTimeDefined => _lifeTime > float.Epsilon;
    private bool _shouldDetonate;

    private void Start()
    {
      _shouldDetonate = IsLifeTimeDefined && _detonateAfterLifeTimeExpired;
      StartCoroutine(DestroyAfterLifeTimeExpired());
    }

    private void OnDrawGizmosSelected()
    {
      Gizmos.color = new Color32(128, 64, 64, 128);
      Gizmos.DrawSphere(_point.position, _radius);
    }

    private IEnumerator DestroyAfterLifeTimeExpired()
    {
      yield return new WaitForSeconds(_lifeTime);
      Destroy(gameObject);

      if (_shouldDetonate)
        Hit();
    }

    public void Hit()
    {
      _shouldDetonate = false;
      if (_hitFx)
        Instantiate(_hitFx, _point.position, Quaternion.identity);
      UpdateTargets();
      foreach (ProjectileTarget splashTarget in _targets)
        splashTarget.GetHit();
    }

    private void UpdateTargets()
    {
      _targets.Clear();

      int overlapsCount = Physics2D.OverlapCircleNonAlloc(_point.position, _radius, _overlappedColliders, _targetLayers);
      if (overlapsCount == 0) return;

      for (int index = 0; index < overlapsCount; index++)
      {
        Collider2D overlappedCollider = _overlappedColliders[index];
        if (!overlappedCollider.TryGetComponent(out ProjectileTarget target)) continue;

        _targets.Add(target);
      }
    }
  }
}