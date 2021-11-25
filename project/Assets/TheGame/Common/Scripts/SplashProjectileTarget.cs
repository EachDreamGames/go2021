using Unity.Mathematics;
using UnityEngine;

namespace TheGame.Common
{
  public class SplashProjectileTarget : ProjectileTarget
  {
    [SerializeField] private GameObject _coveredPrefab;

    public override void GetHit()
    {
      Instantiate(_coveredPrefab, transform.position, quaternion.identity);
      Destroy(gameObject);
    }
  }
}