using Unity.Mathematics;
using UnityEngine;

namespace TheGame.Common
{
  public class SplashTarget : MonoBehaviour
  {
    [SerializeField] private GameObject _coveredPrefab;

    public void Cover()
    {
      Instantiate(_coveredPrefab, transform.position, quaternion.identity);
      Destroy(gameObject);
    }
  }
}