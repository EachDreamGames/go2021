using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TheGame.Common
{
  public class ProjectileCore : MonoBehaviour
  {
    [SerializeField, SuffixLabel("s")] private float _lifeTime;
    [SerializeField] private Transform _point;
    [SerializeField] private GameObject _splashFx;
    [SerializeField] private float _radius;

    private readonly Collider2D[] _overlappedColliders = new Collider2D[10];
    private readonly List<SplashTarget> _splashTargets = new List<SplashTarget>();

    private void Start() =>
      StartCoroutine(SplashAfterLifeTimeExpired());

    private void OnDrawGizmosSelected()
    {
      Gizmos.color = new Color32(128, 64, 64, 128);
      Gizmos.DrawSphere(_point.position, _radius);
    }

    private IEnumerator SplashAfterLifeTimeExpired()
    {
      yield return new WaitForSeconds(_lifeTime);
      Splash();
    }

    public void Splash()
    {
      Destroy(gameObject);

      Instantiate(_splashFx, _point.position, Quaternion.identity);
      UpdateSplashTargets();
      foreach (SplashTarget splashTarget in _splashTargets) 
        splashTarget.Cover();
    }

    private void UpdateSplashTargets()
    {
      _splashTargets.Clear();

      int overlapsCount = Physics2D.OverlapCircleNonAlloc(_point.position, _radius, _overlappedColliders);
      if (overlapsCount == 0) return;

      for (int index = 0; index < overlapsCount; index++)
      {
        Collider2D overlappedCollider = _overlappedColliders[index];
        if (!overlappedCollider.TryGetComponent(out SplashTarget target)) continue;

        _splashTargets.Add(target);
      }
    }
  }
}