using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace TheGame.Common
{
  public class ProjectileCore : MonoBehaviour
  {
    [SerializeField, SuffixLabel("s")] private float _lifeTime;

    private void Start() =>
      StartCoroutine(SplashAfterLifeTimeExpired());

    private IEnumerator SplashAfterLifeTimeExpired()
    {
      yield return new WaitForSeconds(_lifeTime);
      Splash();
    }

    public void Splash() =>
      Destroy(gameObject);
  }
}